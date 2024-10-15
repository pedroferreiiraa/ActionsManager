using _5W2H.Application.Commands.ActionsCommands.CompleteAction;
using _5W2H.Application.Commands.ActionsCommands.DeleteAction;
using _5W2H.Application.Commands.ActionsCommands.InsertAction;
using _5W2H.Application.Commands.ActionsCommands.StartAction;
using _5W2H.Application.Commands.ActionsCommands.UpdateAction;
using _5W2H.Application.Commands.ProjectsCommands.InsertProject;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace _5W2H.Api.Controllers;

[ApiController]
[Route("api/projects")]
public class ProjectController : ControllerBase
{
    private readonly IMediator _mediator;
    public ProjectController(IMediator mediator)
    {
        _mediator = mediator;
            
    }

    // [HttpGet]
    // public async Task<IActionResult> Get(string search = "")
    // {
    //     var query = new GetAllProjectsQuery();
    //     var result = await _mediator.Send(query);
    //
    //     return Ok(result);
    // }
    //
    // [HttpGet("{id}")]
    // public async Task<IActionResult> GetById(int id)
    // {
    //     var result = await _mediator.Send(new GetProjectByIdQuery(id));
    //     return Ok(result);
    // }
    
    
    
    [HttpPost]
    public async Task<IActionResult> Post(InsertProjectCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    // [HttpPut("{id}")]
    // public async Task<IActionResult> Put(int id, UpdateProjectCommand command)
    // {
    //     await _mediator.Send(command);
    //     return NoContent();
    // }
    //
    // [HttpPut("{id}/start")]
    // public async Task<IActionResult> Start(StartProjectCommand command)
    // {
    //     await _mediator.Send(command);
    //     return NoContent();
    // }
    //
    // [HttpPut("{id}/complete")]
    // public async Task<IActionResult> Complete(CompleteProjectCommand command)
    // {        
    //     await _mediator.Send(command);
    //     return NoContent();
    // }
    //
    // [HttpDelete("{id}/delete")]
    // public async Task<IActionResult> Delete(DeleteProjectCommand command)
    // {
    //     await _mediator.Send(command);
    //     return NoContent();
    // }
}