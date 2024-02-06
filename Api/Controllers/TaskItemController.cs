using Api.Abstractions;
using Application.TaskItems.Commands.CreateTaskItem;
using Application.TaskItems.Commands.UpdateTaskItem;
using Application.TaskItems.DTOs.Inbound;
using Application.TaskItems.Queries.GetAllTaskItems;
using Application.TaskItems.Queries.GetTaskItemById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("[controller]s")]
public class TaskItemController : ApiController
{
    public TaskItemController(ISender sender) : base(sender) { }
    
    [HttpPost("")]
    public async Task<IActionResult> CreateTaskItem([FromBody] CreateTaskItemDto taskItem, CancellationToken cancellationToken)
    {
        var command = new CreateTaskItemCommand(taskItem);

        await Sender.Send(command, cancellationToken);

        return Ok();
    }
    
    [HttpPut("")]
    public async Task<IActionResult> UpdateTaskItem([FromBody] UpdateTaskItemDto update, CancellationToken cancellationToken)
    {
        var command = new UpdateTaskItemCommand(update);

        await Sender.Send(command, cancellationToken);

        return Ok();
    }
    
    [HttpGet("")]
    public async Task<IActionResult> GetAllTaskItems(CancellationToken cancellationToken)
    {
        var query = new GetAllTaskItemsQuery();

        var response = await Sender.Send(query, cancellationToken);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTaskItemById(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetTaskItemByIdQuery(id);

        var response = await Sender.Send(query, cancellationToken);

        return Ok(response);
    }
}