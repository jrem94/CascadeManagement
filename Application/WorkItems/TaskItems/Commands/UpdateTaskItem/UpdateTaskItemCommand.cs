using Application.Abstractions;
using Application.DTOs.WorkItems.TaskItems.Inbound;

namespace Application.WorkItems.TaskItems.Commands.UpdateTaskItem;

public sealed record UpdateTaskItemCommand(UpdateTaskItemDto UpdateTaskItemDto) : ICommand;