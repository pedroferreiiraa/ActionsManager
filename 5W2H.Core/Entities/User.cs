using _5W2H.Core.Enums;

namespace _5W2H.Core.Entities;

public class User : BaseEntity
{
    public User(int id, string fullName, string email, bool active, string password, RoleEnums role, List<Project> projects, List<Project> ownedProjects, DateTime createdAt)
    {
        
        FullName = fullName;
        Email = email;
        Active = active;
        Password = password;
        Role = role;
        Projects = projects;
        OwnedProjects = ownedProjects;
        CreatedAt = createdAt;
    }

    

    public string FullName { get; private set; }
    public string Email { get; private set; }
    public bool Active { get; set; }
    public string Password { get; private set; }
    public RoleEnums Role  { get; private set; }
    
    public List<Project> Projects { get; private set; }
    public List<Project> OwnedProjects { get; private set; }
    public DateTime CreatedAt { get; private set; }
    
    
}