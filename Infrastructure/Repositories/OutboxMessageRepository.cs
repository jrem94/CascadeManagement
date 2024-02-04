using Application.Repositories;
using Domain.Entities.OutboxMessage;

namespace Infrastructure.Repositories;

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