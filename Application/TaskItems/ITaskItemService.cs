using Application.TaskItems.DTOs;
using Domain.Entities.WorkItem;

namespace Application.TaskItems;

public interface ITaskItemService
{
    Task<TaskItem> CreateTaskItem(TaskItemDto taskItemDto);

    Task<TaskItem> UpdateTaskItem(Guid id, TaskItemDto taskItemDto);

    Task<List<TaskItem>> GetAllTaskItems();

    Task<TaskItem> GetTaskItemById(Guid id);
}