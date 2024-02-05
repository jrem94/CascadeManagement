using Application.Abstractions;
using Application.DataProviderInterfaces;
using Application.DTOs.WorkItems.TaskItems.Outbound;
using Domain.Entities.WorkItem;

namespace Application.WorkItems.TaskItems.Queries.GetTaskItemById;

public class GetTaskItemByIdQueryHandler : IQueryHandler<GetTaskItemByIdQuery, ClientTaskItemDto?>
{
    private readonly IQueryableDataSource _queryableDataSource;
    
    public GetTaskItemByIdQueryHandler(IQueryableDataSource queryableDataSource)
    {
        _queryableDataSource = queryableDataSource;
    }
    
    public async Task<ClientTaskItemDto?> Handle(GetTaskItemByIdQuery request, CancellationToken cancellationToken)
    {
        var taskItem = await _queryableDataSource
            .QuerySingle<TaskItem>($"select * from TaskItem where Id = {request.Id}");

        if (taskItem is null)
            throw new Exception($"No Task Item found with Id {request.Id}");

        return ClientTaskItemDto.FromTaskItem(taskItem);
    }
}