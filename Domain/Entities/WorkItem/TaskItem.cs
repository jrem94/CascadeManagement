using Domain.DomainEvents.WorkItems.TaskItems;

namespace Domain.Entities.WorkItem;

public class TaskItem : WorkItem
{
    private TaskItem(Guid id, string title, string description) : base(id, title, description) { }

    public static TaskItem Create(string title, string description)
    {
        var taskItem = new TaskItem(new Guid(), title, description);
        
        return taskItem;
    }

    public void Update(string title, string description)
    {
        Title = title;
        Description = description;
        
        RaiseEvent(new TaskItemUpdatedDomainEvent(Id));
    }
}