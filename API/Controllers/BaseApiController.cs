using Domain.Commons.Errors;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers;



[Route("api/[controller]")]
[ApiController]
public class BaseApiController : ControllerBase
{
    private IMediator? _mediator;

    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<IMediator>();


   

    protected IActionResult HandleResult<T>(Result<T> result)
    {
        if (result.IsFailed)
        {
            var error = result.Errors.FirstOrDefault();
            if (error is NotFoundError)
            {
                return NotFound(error.Message ?? "Resource not found.");
            }

            return BadRequest(error?.Message ?? "An error occurred while processing your request.");
        }

        return Ok(result.Value);
    }
}
