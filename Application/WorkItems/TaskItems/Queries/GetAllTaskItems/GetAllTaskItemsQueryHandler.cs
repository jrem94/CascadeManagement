using Application.Abstractions;
using Application.DataProviderInterfaces;
using Application.DTOs.WorkItems.TaskItems;
using Application.DTOs.WorkItems.TaskItems.Outbound;
using Domain.Entities.WorkItem;

namespace Application.WorkItems.TaskItems.Queries.GetAllTaskItems;

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
            .Query<TaskItem>($"select * from TaskItem");

        return taskItems.Select(ClientTaskItemDto.FromTaskItem).ToList();
    }
}