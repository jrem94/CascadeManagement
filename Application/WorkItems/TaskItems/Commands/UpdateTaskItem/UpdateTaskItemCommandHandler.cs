using Application.Abstractions;
using Application.Repositories;
using Application.UnitOfWork;
using Domain.Entities.WorkItem;

namespace Application.WorkItems.TaskItems.Commands.UpdateTaskItem;

public class UpdateTaskItemCommandHandler : ICommandHandler<UpdateTaskItemCommand>
{
    private readonly ITaskItemRepository _taskItemRepository;
    private readonly IQueryRepository<TaskItem> _queryRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public UpdateTaskItemCommandHandler(ITaskItemRepository taskItemRepository, IQueryRepository<TaskItem> queryRepository,
        IUnitOfWork unitOfWork)
    {
        _taskItemRepository = taskItemRepository;
        _queryRepository = queryRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task Handle(UpdateTaskItemCommand request, CancellationToken cancellationToken)
    {
        var update = request.UpdateTaskItemDto;

        var taskItem = await _queryRepository.GetByIdAsync(update.Id);
        
        if (taskItem is null)
            throw new Exception($"No Task Item found with Id {update.Id}");

        taskItem.Update(update.Title, update.Description);
        
        _taskItemRepository.Update(taskItem);
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}