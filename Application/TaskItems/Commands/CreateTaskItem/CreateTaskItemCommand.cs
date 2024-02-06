using Application.Abstractions;
using Application.TaskItems.DTOs.Inbound;

namespace Application.TaskItems.Commands.CreateTaskItem;

public sealed record CreateTaskItemCommand(CreateTaskItemDto CreateTaskItemDto) : ICommand;