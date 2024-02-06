using Application.InfrastructurePorts;
using Domain.Entities.OutboxMessage;

namespace Infrastructure.DataProviders;

public class OutboxMessageRepository : IOutboxMessageRepository
{
    private readonly CascadeManagementDbContext _dbContext;
    
    public OutboxMessageRepository(CascadeManagementDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Delete(OutboxMessage outboxMessage)
    {
        _dbContext.Remove(outboxMessage);
    }
}