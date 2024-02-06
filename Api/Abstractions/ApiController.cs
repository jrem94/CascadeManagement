using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Abstractions;

[ApiController]
[Route("[controller]s")]
public abstract class ApiController : ControllerBase
{
}