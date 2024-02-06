namespace Application.TaskItems.DTOs.Inbound;

public sealed class CreateTaskItemDto
{
    public string? Title { get; set; }
    
    public string? Description { get; set; }
}