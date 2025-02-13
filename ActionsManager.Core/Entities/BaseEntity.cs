namespace _5W2H.Core.Entities;

public abstract class BaseEntity
{
    protected BaseEntity()
    {
        CreatedAt = DateTime.UtcNow;
        IsDeleted = false;
    }

    public int Id { get; private set; }
    public DateTime CreatedAt { get; private set; } 
    public bool IsDeleted { get; private set; }

    public void SetAsDeleted()
    {
        IsDeleted = true;
    }
}