using Domain.Entities.WorkItem;

namespace Application.DTOs.WorkItems.TaskItems.Inbound;

public sealed class CreateTaskItemDto
{
    public string Title { get; set; }
    
    public string Description { get; set; }

    public CreateTaskItemDto(string title, string description)
    {
        Title = title;
        Description = description;
    }

    public static CreateTaskItemDto FromTaskItem(TaskItem taskItem)
    {
        return new CreateTaskItemDto(taskItem.Title, taskItem.Description);
    }
}