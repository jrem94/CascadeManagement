using Application.Abstractions;
using Application.TaskItems.DTOs.Outbound;

namespace Application.TaskItems.Queries.GetAllTaskItems;

public sealed record GetAllTaskItemsQuery() : IQuery<List<ClientTaskItemDto>>;