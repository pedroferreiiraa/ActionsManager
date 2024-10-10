using _5W2H.Core.Entities;
using _5W2H.Core.Enums;

namespace _5W2H.Application.Models;

public class UserViewModel
{
    public UserViewModel(User user)
    {
        FullName = user.FullName;
        Email = user.Email;
        Id = user.Id;
        Role = user.Role;
    }


    public int Id { get; set; }
    public string FullName { get;  set; }
    public string Email { get;  set; }
    public RoleEnums Role {get; set; }
    
}