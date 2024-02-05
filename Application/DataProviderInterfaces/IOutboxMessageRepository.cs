using Domain.Entities.OutboxMessage;

namespace Application.DataProviderInterfaces;

public interface IOutboxMessageRepository
{
    void Delete(OutboxMessage outboxMessage);
}