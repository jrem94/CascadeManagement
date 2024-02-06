using Application.InfrastructurePorts;
using Domain.Abstractions;
using Domain.Entities;
using Domain.Entities.OutboxMessage;

namespace Infrastructure.DataProviders;

public sealed class UnitOfWork : IUnitOfWork
{
    private readonly CascadeManagementDbContext _dbContext;
    
    public UnitOfWork(CascadeManagementDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        ConvertDomainEventsToOutboxMessages();
        
        return _dbContext.SaveChangesAsync(cancellationToken);
    }

    private void ConvertDomainEventsToOutboxMessages()
    {
        var outboxMessages = _dbContext.ChangeTracker
            .Entries<AggregateRoot>()
            .Select(x => x.Entity)
            .SelectMany(aggregateRoot => aggregateRoot.PullDomainEvents())
            .Select(OutboxMessage.CreateFromDomainEvent)
            .ToList();
        
        _dbContext.Set<OutboxMessage>().AddRange(outboxMessages);
    }
}