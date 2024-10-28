using _5W2H.Application.Commands.ActionsCommands.CompleteAction;
using _5W2H.Application.Commands.ActionsCommands.DeleteAction;
using _5W2H.Application.Commands.ActionsCommands.InsertAction;
using _5W2H.Application.Commands.ActionsCommands.StartAction;
using _5W2H.Application.Commands.ActionsCommands.UpdateAction;
using _5W2H.Application.Commands.ActionsCommands.UpdateConclusionTextAction;
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
    public async Task<IActionResult> Start(int id, [FromBody] StartActionCommand command)
    {
        if (command.Id != id)
        {
            return BadRequest(new { message = "O ID no corpo da requisição não coincide com o ID da URL." });
        }
        
        var result = await _mediator.Send(command);

        if (!result.IsSuccess)
        {
            return BadRequest(new { message = result.Message });
        }
        
        return Ok(new { isSuccess = true, message = "Ação iniciada com sucesso." });
    }

    [HttpPut("{id}/complete")]
    public async Task<IActionResult> Complete(int id)
    {        
        var command = new CompleteActionCommand(id);
        var result = await _mediator.Send(command);

        if (!result.IsSuccess)
        {
            return BadRequest(new { message = result.Message });
        }
        
        return Ok(new { isSuccess = true, message = "Ação completada com sucesso." });
    }

    [HttpDelete("{id}/delete")]
    public async Task<IActionResult> Delete(DeleteActionCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpPatch("{id}/conclusion")]
    public async Task<IActionResult> Conclusion(int id, [FromBody] UpdateConclusionTextActionCommand command)
    {
        if (id != command.ActionId)
        {
            return BadRequest("O ID da ação não corresponde ao fornecido na URL.");
        }
        
        await _mediator.Send(command);
        
        return NoContent();
    }
    
}