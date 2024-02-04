using Application.Abstractions;
using Application.DTOs.WorkItems.TaskItems.Outbound;
using Domain.Entities.WorkItem;

namespace Application.WorkItems.TaskItems.Queries.GetAllTaskItems;

public sealed record GetAllTaskItemsQuery() : IQuery<List<ClientTaskItemDto>>;