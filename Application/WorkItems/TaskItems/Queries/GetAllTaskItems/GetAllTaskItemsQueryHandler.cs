using Application.Abstractions;
using Application.DTOs.WorkItems.TaskItems.Outbound;
using Application.Repositories;
using Domain.Entities.WorkItem;

namespace Application.WorkItems.TaskItems.Queries.GetAllTaskItems;

public class GetAllTaskItemsQueryHandler : IQueryHandler<GetAllTaskItemsQuery, List<ClientTaskItemDto>>
{
    private readonly IQueryRepository<TaskItem> _queryRepository;
    
    public GetAllTaskItemsQueryHandler(IQueryRepository<TaskItem> queryRepository)
    {
        _queryRepository = queryRepository;
    }
    
    public async Task<List<ClientTaskItemDto>> Handle(GetAllTaskItemsQuery request, CancellationToken cancellationToken)
    {
        var taskItems = await _queryRepository.GetAllAsync();

        return taskItems.Select(ClientTaskItemDto.FromTaskItem).ToList();
    }
}