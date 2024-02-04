using Application.DTOs.WorkItems.TaskItems.Inbound;
using Application.Repositories;
using Domain.Entities.WorkItem;

namespace Infrastructure.Repositories;

public sealed class TaskItemRepository : ITaskItemRepository
{
    private readonly CascadeManagementDbContext _dbContext;
    
    public TaskItemRepository(CascadeManagementDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public void Add(TaskItem taskItem)
    {
        _dbContext.Add(taskItem);
    }

    public void Update(TaskItem taskItemUpdate)
    {
        _dbContext.Update(taskItemUpdate);
    }
}