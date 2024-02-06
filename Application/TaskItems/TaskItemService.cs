using Application.InfrastructurePorts;
using Application.TaskItems.DTOs;
using Domain.Entities.WorkItem;

namespace Application.TaskItems;

public class TaskItemService : ITaskItemService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITaskItemRepository _taskItemRepository;
    private readonly IQueryableDataSource _queryableDataSource;
    
    public TaskItemService(IUnitOfWork unitOfWork, ITaskItemRepository taskItemRepository, IQueryableDataSource queryableDataSource)
    {
        _unitOfWork = unitOfWork;
        _taskItemRepository = taskItemRepository;
        _queryableDataSource = queryableDataSource;
    }
    
    public async Task<TaskItem> CreateTaskItem(TaskItemDto taskItemDto)
    {
        if (taskItemDto.Title is null || taskItemDto.Description is null)
            throw new ArgumentException("TaskItemDto was incomplete and could not be used in operation.");
        
        var taskItem = TaskItem.Create(taskItemDto.Title, taskItemDto.Description);
        
        _taskItemRepository.Add(taskItem);

        await _unitOfWork.SaveChangesAsync();

        return taskItem;
    }

    public async Task<TaskItem> UpdateTaskItem(Guid id, TaskItemDto taskItemDto)
    {
        if (taskItemDto.Title is null || taskItemDto.Description is null)
            throw new ArgumentException("TaskItemDto was incomplete and could not be used in operation.");

        var taskItem = await _queryableDataSource
            .QuerySingle<TaskItem>($"select * from TaskItem where Id = {id}");
        
        if (taskItem is null)
            throw new Exception($"No TaskItem with Id {id} was found.");
        
        taskItem.Update(taskItemDto.Title, taskItemDto.Description);
        
        _taskItemRepository.Update(taskItem);

        await _unitOfWork.SaveChangesAsync();

        return taskItem;
    }

    public async Task<List<TaskItem>> GetAllTaskItems()
    {
        return await _queryableDataSource.QueryList<TaskItem>($"select * from TaskItem");
    }

    public async Task<TaskItem> GetTaskItemById(Guid id)
    {
        var taskItem = await _queryableDataSource.QuerySingle<TaskItem>($"select * from TaskItem where Id = {id}");

        if (taskItem is null)
            throw new Exception($"No TaskItem with Id {id} was found.");
        
        return taskItem;
    }
}