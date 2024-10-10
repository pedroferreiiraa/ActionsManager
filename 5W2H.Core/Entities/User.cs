using _5W2H.Core.Enums;

namespace _5W2H.Core.Entities;

public class User : BaseEntity
{
    public User( string fullName, string email,  string password, RoleEnums role)
    {
        
        FullName = fullName;
        Email = email;
        Password = password;
        Role = role;
      

    }

    public string FullName { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public RoleEnums Role  { get; private set; }
    
    
    public void Update(string fullName, string email,  RoleEnums role)
    {
        FullName = fullName;
        Email = email;
        Role = role;
    }
    
    
}