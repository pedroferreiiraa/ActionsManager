using _5W2H.Application.Commands.ActionsCommands.CompleteAction;
using _5W2H.Application.Commands.ActionsCommands.DeleteAction;
using _5W2H.Application.Commands.ActionsCommands.InsertAction;
using _5W2H.Application.Commands.ActionsCommands.StartAction;
using _5W2H.Application.Commands.ActionsCommands.UpdateAction;
using _5W2H.Application.Queries.ActionQueries.GetActionById;
using _5W2H.Application.Queries.ActionQueries.GetAllActions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _5W2H.Api.Controllers;

[ApiController]
[Route("/api/actions")]

public class ActionController : ControllerBase
{
    private readonly IMediator _mediator;
    public ActionController(IMediator mediator)
    {
        _mediator = mediator;
            
    }

    [HttpGet]
    public async Task<IActionResult> Get(string search = "")
    {
        var query = new GetAllActionsQuery();
        var result = await _mediator.Send(query);

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var query = new GetActionByIdQuery(id);
        
        var action = await _mediator.Send(query);

        if (action == null)
        {
            return NotFound();
        }

        return Ok(action);
    }
    
    
    
    [HttpPost]
    public async Task<IActionResult> Post(InsertActionCommand command)
    {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = result.Data }, command);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, UpdateActionCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpPut("{id}/start")]
    public async Task<IActionResult> Start(StartActionCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpPut("{id}/complete")]
    public async Task<IActionResult> Complete(CompleteActionCommand command)
    {        
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}/delete")]
    public async Task<IActionResult> Delete(DeleteActionCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }
    
}