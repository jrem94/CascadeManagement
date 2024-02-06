using Application.Abstractions;
using Application.TaskItems.DTOs.Outbound;

namespace Application.TaskItems.Queries.GetTaskItemById;

public sealed record GetTaskItemByIdQuery(Guid Id) : IQuery<ClientTaskItemDto?>;