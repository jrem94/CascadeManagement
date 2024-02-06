using Domain.Entities.WorkItem;

namespace Application.InfrastructurePorts;

public interface ITaskItemRepository
{
    void Add(TaskItem taskItem);

    void Update(TaskItem taskItemUpdate);
}