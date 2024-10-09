using _5W2H.Core.Entities;
using _5W2H.Core.Enums;
using MediatR;

namespace _5W2H.Application.Commands.UserCommands.InsertUser;

public class InsertUserCommand : IRequest<int>
{
    public string FullName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public RoleEnums Role { get; set; }
    
    public User ToEntity()
        => new User(0, FullName, Email, true, Password, Role, new List<Project>(), new List<Project>(), DateTime.Now);

}