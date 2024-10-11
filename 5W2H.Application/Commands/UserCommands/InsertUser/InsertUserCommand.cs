using _5W2H.Core.Entities;
using _5W2H.Core.Enums;
using MediatR;

namespace _5W2H.Application.Commands.UserCommands.InsertUser;

public class InsertUserCommand : IRequest<int>
{
  
    public string FullName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
    public DepartmentEnum Department { get; set; }
    
    public User ToEntity(string passwordHash)
        => new User( FullName, Email,  passwordHash, Role, Department);

}