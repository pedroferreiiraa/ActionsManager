using _5W2H.Application.Commands.ProjectCommands.CompleteProject;
using _5W2H.Application.Commands.ProjectCommands.DeleteProject;
using _5W2H.Application.Commands.ProjectCommands.InsertProject;
using _5W2H.Application.Commands.ProjectCommands.StartProject;
using _5W2H.Application.Commands.ProjectCommands.UpdateProject;
using _5W2H.Application.Queries.ProjectQueries.GetAllProjects;
using _5W2H.Application.Queries.ProjectQueries.GetProjectById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace _5W2H.Api.Controllers;

[ApiController]
[Route("/api/projects")]
public class ProjectsController : ControllerBase
{
    private readonly IMediator _mediator;
    public ProjectsController(IMediator mediator)
    {
        _mediator = mediator;
            
    }

    [HttpGet]
    public async Task<IActionResult> Get(string search = "")
    {
        var query = new GetAllProjectsQuery();

        var result = await _mediator.Send(query);

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _mediator.Send(new GetProjectByIdQuery(id));
    
        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }
    
        return Ok(result);
    }
    
    
    
    [HttpPost]
    public async Task<IActionResult> Post(InsertProjectCommand command)
    {
        var result = await _mediator.Send(command);
    
        return CreatedAtAction(nameof(GetById), new { id = result.Data }, command);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, UpdateProjectCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpPut("{id}/start")]
    public async Task<IActionResult> Start(int id)
    {
        var command = new StartProjectCommand(id);
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpPut("{id}/complete")]
    public async Task<IActionResult> Complete(int id)
    {
        var command = new CompleteProjectCommand(id);
        
        await _mediator.Send(command);
        
        return NoContent();
    }

    [HttpDelete("{id}/delete")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteProjectCommand(id);
        
        await _mediator.Send(command);
        
        return NoContent();
    }
    
}