using Application.Abstractions;
using Application.DTOs.WorkItems.TaskItems.Inbound;
using MediatR;

namespace Application.WorkItems.TaskItems.Commands.CreateTaskItem;

public sealed record CreateTaskItemCommand(CreateTaskItemDto CreateTaskItemDto) : ICommand;