using _5W2H.Core.Enums;

namespace _5W2H.Core.Entities;

public class User : BaseEntity
{
    public User(string fullName, string jobRole, RoleEnums role, bool active, List<Project> projects, List<Project> ownedProjects)
    {
        FullName = fullName;
        JobRole = jobRole;
        Role = role;
        Active = active;
        
        
        Projects = [];

    }

    public User()
    {
        
    }
    


    public Guid Id { get; private set; } = new Guid();
    public string FullName { get; private set; }
    public string JobRole { get; private set; }
    
    public RoleEnums Role  { get; private set; }

    
    public bool Active { get; private set; } = true;
    
    public List<Project> Projects { get; private set; }
    public List<Project> OwnedProjects { get; private set; }
    
    
}