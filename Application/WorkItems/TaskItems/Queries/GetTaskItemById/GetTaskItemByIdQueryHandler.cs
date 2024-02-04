using Application.Abstractions;
using Application.DTOs.WorkItems.TaskItems.Outbound;
using Application.Repositories;
using Domain.Entities.WorkItem;

namespace Application.WorkItems.TaskItems.Queries.GetTaskItemById;

public class GetTaskItemByIdQueryHandler : IQueryHandler<GetTaskItemByIdQuery, ClientTaskItemDto?>
{
    private readonly IQueryRepository<TaskItem> _queryRepository;
    
    public GetTaskItemByIdQueryHandler(IQueryRepository<TaskItem> queryRepository)
    {
        _queryRepository = queryRepository;
    }
    
    public async Task<ClientTaskItemDto?> Handle(GetTaskItemByIdQuery request, CancellationToken cancellationToken)
    {
        var taskItem = await _queryRepository.GetByIdAsync(request.Id);

        if (taskItem is null)
            throw new Exception($"No Task Item found with Id {request.Id}");

        return ClientTaskItemDto.FromTaskItem(taskItem);
    }
}