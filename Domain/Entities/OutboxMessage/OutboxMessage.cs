using Domain.DomainEvents;
using Newtonsoft.Json;

namespace Domain.Entities.OutboxMessage;

public class OutboxMessage : Entity
{
    public string? Type { get; private set; }

    public string? Content { get; private set; }
    
    public DateTime CreatedDate { get; private set; }

    private OutboxMessage(Guid id, string? type, string? content)
        : base(id)
    {
        Type = type;
        Content = content;
        CreatedDate = DateTime.Now;
    }

    public static OutboxMessage CreateFromDomainEvent(IDomainEvent domainEvent)
    {
        var outboxMessage = new OutboxMessage(
            new Guid(),
            domainEvent.GetType().Name,
            JsonConvert.SerializeObject(domainEvent, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All }));

        return outboxMessage;
    }
}