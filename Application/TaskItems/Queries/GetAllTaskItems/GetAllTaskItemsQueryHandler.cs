using Application.Abstractions;
using Application.InfrastructurePorts;
using Application.TaskItems.DTOs.Outbound;
using Domain.Entities.WorkItem;

namespace Application.TaskItems.Queries.GetAllTaskItems;

public class GetAllTaskItemsQueryHandler : IQueryHandler<GetAllTaskItemsQuery, List<ClientTaskItemDto>>
{
    private readonly IQueryableDataSource _queryableDataSource;
    
    public GetAllTaskItemsQueryHandler(IQueryableDataSource queryableDataSource)
    {
        _queryableDataSource = queryableDataSource;
    }
    
    public async Task<List<ClientTaskItemDto>> Handle(GetAllTaskItemsQuery request, CancellationToken cancellationToken)
    {
        var taskItems = await _queryableDataSource
            .QueryList<TaskItem>($"select * from TaskItem");

        return taskItems.Select(ClientTaskItemDto.FromTaskItem).ToList();
    }
}