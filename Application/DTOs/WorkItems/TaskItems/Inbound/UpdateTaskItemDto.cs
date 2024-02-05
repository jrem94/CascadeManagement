namespace Application.DTOs.WorkItems.TaskItems.Inbound;

public class UpdateTaskItemDto
{
    public Guid Id { get; set; }
    
    public string? Title { get; set; }

    public string? Description { get; set; }
}