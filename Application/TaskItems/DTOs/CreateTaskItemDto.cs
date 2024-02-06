namespace Application.TaskItems.DTOs;

public sealed record TaskItemDto
{
    public string? Title { get; set; }
    
    public string? Description { get; set; }
}