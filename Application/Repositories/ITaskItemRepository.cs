using Application.DTOs.WorkItems.TaskItems.Inbound;
using Domain.Entities.WorkItem;

namespace Application.Repositories;

public interface ITaskItemRepository
{
    void Add(TaskItem taskItem);

    void Update(TaskItem taskItemUpdate);
}