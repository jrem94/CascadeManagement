using Domain.Entities.WorkItem;

namespace Application.DataProviderInterfaces;

public interface ITaskItemRepository
{
    void Add(TaskItem taskItem);

    void Update(TaskItem taskItemUpdate);
}