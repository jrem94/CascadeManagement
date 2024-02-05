using Domain.Abstractions;

namespace Domain.Entities.WorkItem;

public abstract class WorkItem : AggregateRoot
{
    public string Title { get; protected set; }

    public string Description { get; protected set; }

    protected WorkItem(Guid id, string title, string description) : base(id)
    {
        Title = title;
        Description = description;
    }
}