using Domain.Entities.WorkItem;

namespace Application.DTOs.WorkItems.TaskItems.Inbound;

public sealed class CreateTaskItemDto
{
    public string? Title { get; set; }
    
    public string? Description { get; set; }
}