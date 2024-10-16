using _5W2H.Application.Commands.UserCommands.DeleteUser;
using _5W2H.Application.Commands.UserCommands.InsertUser;
using _5W2H.Application.Commands.UserCommands.LoginUser;
using _5W2H.Application.Commands.UserCommands.UpdateUser;
using _5W2H.Application.Queries.UsersQueries.GetAllUsers;
using _5W2H.Application.Queries.UsersQueries.GetUserById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _5W2H.Api.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;
    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var query = new GetAllUsersQuery();
        
        var users = await _mediator.Send(query);
        
        return Ok(users);
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
    public async Task<IActionResult> Post([FromBody] InsertUserCommand command)
    {
        
        var user = await _mediator.Send(command);
        return Ok(user);

    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] UpdateUserCommand command)
    {
        // Validar se o ID no comando coincide com o ID na URL
        if (id != command.Id)
        {
            return BadRequest("ID do usuário não coincide com o comando.");
        }

        // Enviar o comando para o Mediator
        var result = await _mediator.Send(command);

        // Verificar o resultado da operação
        if (!result.IsSuccess)
        {
            return NotFound(result.Message);
        }

        return Ok(result);
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(DeleteUserCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpPut("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
    {
        var loginUserViewModel = await _mediator.Send(command);

        if (loginUserViewModel == null)
        {
            return BadRequest();
        }
        
        return Ok(loginUserViewModel);
    }
    
    
}