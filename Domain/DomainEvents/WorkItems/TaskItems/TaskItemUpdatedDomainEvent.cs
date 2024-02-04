namespace Domain.DomainEvents.WorkItems.TaskItems;

public sealed record TaskItemUpdatedDomainEvent(Guid Id) : IDomainEvent;