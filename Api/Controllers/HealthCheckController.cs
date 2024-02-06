using Api.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class HealthCheckController : ApiController
{
    [HttpGet("")]
    public async Task<IActionResult> GetHealthStatus()
    {
        return await Task.Run(() => Ok("Application is Healthy!"));
    }
}