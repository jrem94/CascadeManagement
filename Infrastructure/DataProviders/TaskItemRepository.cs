using Application.DataProviderInterfaces;
using Domain.Entities.WorkItem;

namespace Infrastructure.DataProviders;

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