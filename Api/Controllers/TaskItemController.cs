using Api.Abstractions;
using Application.TaskItems;
using Application.TaskItems.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class TaskItemController : ApiController
{
    private readonly ITaskItemService _taskItemService;
    
    public TaskItemController(ITaskItemService taskItemService)
    {
        _taskItemService = taskItemService;
    }
    
    [HttpPost("")]
    public async Task<IActionResult> CreateTaskItem([FromBody] TaskItemDto taskItemDto)
    {
        var createdTaskItem = await _taskItemService.CreateTaskItem(taskItemDto);

        return Ok(createdTaskItem);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTaskItem([FromBody] TaskItemDto taskItemDto, Guid id)
    {
        var updatedTaskItem = await _taskItemService.UpdateTaskItem(id, taskItemDto);

        return Ok(updatedTaskItem);
    }
    
    [HttpGet("")]
    public async Task<IActionResult> GetAllTaskItems()
    {
        var taskItems = await _taskItemService.GetAllTaskItems();

        return Ok(taskItems);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTaskItemById(Guid id)
    {
        var taskItem = await _taskItemService.GetTaskItemById(id);

        return Ok(taskItem);
    }
}