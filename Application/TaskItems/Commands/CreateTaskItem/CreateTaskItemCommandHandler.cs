using Application.Abstractions;
using Application.InfrastructurePorts;
using Domain.Entities.WorkItem;

namespace Application.TaskItems.Commands.CreateTaskItem;

public sealed class CreateTaskItemCommandHandler : ICommandHandler<CreateTaskItemCommand>
{
    private readonly ITaskItemRepository _taskItemRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public CreateTaskItemCommandHandler(ITaskItemRepository taskItemRepository, IUnitOfWork unitOfWork)
    {
        _taskItemRepository = taskItemRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task Handle(CreateTaskItemCommand request, CancellationToken cancellationToken)
    {
        var dto = request.CreateTaskItemDto;
        
        var taskItem = TaskItem.Create(dto.Title, dto.Description);
        
        _taskItemRepository.Add(taskItem);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}