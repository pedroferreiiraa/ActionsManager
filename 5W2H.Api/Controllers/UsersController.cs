using _5W2H.Application.Commands.UserCommands.InsertUser;
using _5W2H.Application.Queries.UsersQueries.GetUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace _5W2H.Api.Controllers;

[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;
    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var query = new GetUserQuery(id);
        
        var user = await _mediator.Send(query);

        if (user == null)
        {
            return NotFound();
        }

        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> Post(InsertUserCommand command)
    {
        var user = await _mediator.Send(command);

        if (user == null)
        {
            return null;
        }

        return CreatedAtAction(nameof(GetById), command);

    }
    
}