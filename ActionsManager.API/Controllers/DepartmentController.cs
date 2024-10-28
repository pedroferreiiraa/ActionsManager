using _5W2H.Application.Commands.DepartmentCommands.InsertDepartment;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace _5W2H.Api.Controllers;

[ApiController]
[Route("/api/departments")]
public class DepartmentController : ControllerBase
{
    private readonly IMediator _mediator;
    public DepartmentController(IMediator mediator)
    {
        _mediator = mediator;
            
    }
    
    

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] InsertDepartmentCommand command)
    {
        var result = await _mediator.Send(command);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }
}