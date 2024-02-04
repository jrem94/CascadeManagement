using Application.Abstractions;
using Application.DTOs.WorkItems.TaskItems.Outbound;
using Domain.Entities.WorkItem;

namespace Application.WorkItems.TaskItems.Queries.GetTaskItemById;

public sealed record GetTaskItemByIdQuery(Guid Id) : IQuery<ClientTaskItemDto?>;