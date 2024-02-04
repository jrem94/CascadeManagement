using Domain.Entities.OutboxMessage;

namespace Application.Repositories;

public interface IOutboxMessageRepository
{
    void Delete(OutboxMessage outboxMessage);
}