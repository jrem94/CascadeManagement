using Domain.Entities.WorkItem;

namespace Application.DTOs.WorkItems.TaskItems.Outbound;

public sealed class ClientTaskItemDto
{
    public Guid Id { get; set; }
    
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    public ClientTaskItemDto(Guid id, string title, string description)
    {
        Id = id;
        Title = title;
        Description = description;
    }

    public static ClientTaskItemDto FromTaskItem(TaskItem taskItem)
    {
        return new ClientTaskItemDto(taskItem.Id, taskItem.Title, taskItem.Description);
    }
}