using Application.Abstractions;
using Application.TaskItems.DTOs.Inbound;

namespace Application.TaskItems.Commands.UpdateTaskItem;

public sealed record UpdateTaskItemCommand(UpdateTaskItemDto UpdateTaskItemDto) : ICommand;