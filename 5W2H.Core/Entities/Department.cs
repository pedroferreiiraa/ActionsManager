namespace _5W2H.Core.Entities;

public class Department : BaseEntity
{
    public Department() {}
    public Department(int id, string description, List<User> users)
    {
        Id = id;
        Description = description;
        Users = users;
    }

    public int Id { get; private set; }
    public string Description { get; private set; }
    public List<User> Users { get; private set; }
}