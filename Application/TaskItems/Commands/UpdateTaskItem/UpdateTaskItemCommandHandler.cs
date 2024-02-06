using Application.Abstractions;
using Application.InfrastructurePorts;
using Domain.Entities.WorkItem;

namespace Application.TaskItems.Commands.UpdateTaskItem;

public class UpdateTaskItemCommandHandler : ICommandHandler<UpdateTaskItemCommand>
{
    private readonly ITaskItemRepository _taskItemRepository;
    private readonly IQueryableDataSource _queryableDataSource;
    private readonly IUnitOfWork _unitOfWork;
    
    public UpdateTaskItemCommandHandler(ITaskItemRepository taskItemRepository, IQueryableDataSource queryableDataSource,
        IUnitOfWork unitOfWork)
    {
        _taskItemRepository = taskItemRepository;
        _queryableDataSource = queryableDataSource;
        _unitOfWork = unitOfWork;
    }
    
    public async Task Handle(UpdateTaskItemCommand request, CancellationToken cancellationToken)
    {
        var update = request.UpdateTaskItemDto;

        var taskItem = await _queryableDataSource
            .QuerySingle<TaskItem>($"select * from TaskItem where Id = {update.Id}");
        
        if (taskItem is null)
            throw new Exception($"No Task Item found with Id {update.Id}");

        taskItem.Update(update.Title, update.Description);
        
        _taskItemRepository.Update(taskItem);
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}