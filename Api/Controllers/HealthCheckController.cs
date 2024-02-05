using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class HealthCheckController : ControllerBase
{
    [HttpGet("")]
    public async Task<IActionResult> GetHealthStatus()
    {
        return await Task.Run(() => Ok("Application is Healthy!"));
    }
}