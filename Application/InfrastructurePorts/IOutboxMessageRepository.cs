using Domain.Entities.OutboxMessage;

namespace Application.InfrastructurePorts;

public interface IOutboxMessageRepository
{
    void Delete(OutboxMessage outboxMessage);
}