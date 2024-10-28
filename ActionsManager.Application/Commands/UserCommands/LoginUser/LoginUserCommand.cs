using _5W2H.Application.Models;
using MediatR;

namespace _5W2H.Application.Commands.UserCommands.LoginUser;

public class LoginUserCommand : IRequest<LoginUserViewModel>
{
    public string Email { get; set; }
    public string Password { get; set; }
}