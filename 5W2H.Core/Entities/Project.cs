using _5W2H.Core.Enums;

namespace _5W2H.Core;

public class Project : BaseEntity
{
    public Project(string title, string what, string why, DateTime when, string where, string who, string how, decimal howMuch)
    {
        Title = title;
        What = what;
        Why = why;
        When = when;
        Where = where;
        Who = who;
        How = how;
        HowMuch = howMuch;
    }

    public int Id { get; private set; }
    public string Title { get; private set; }
    public string What { get; private set; }
    public string Why { get; private set; }
    public DateTime When { get; private set; }
    public string Where { get; private set; }
    public string Who { get; private set; }
    public string How { get; private set; }
    public decimal HowMuch { get; private set; }
    
    public Guid IdUser { get; private set; }
    
    public User User { get; private set; }
    
    public DateTime? CreatedAt { get; private set; }
    public DateTime? StartedAt { get; private set; }
    public DateTime? CompletedAt { get; private set; }
    public ProjectStatusEnum Status { get; private set; }

    public void Cancel()
    {
        if (Status == ProjectStatusEnum.InProgress || Status == ProjectStatusEnum.Suspended)
        {
            Status = ProjectStatusEnum.Cancelled;
        }
    }
    
    public void Start()
    {
        if (Status == ProjectStatusEnum.Created)
        {
            Status = ProjectStatusEnum.InProgress;
            StartedAt = DateTime.Now;
        }
    }

    public void Complete()
    {
        if (Status == ProjectStatusEnum.InProgress)
        {
            Status = ProjectStatusEnum.Completed;
            CompletedAt = DateTime.Now;
        }
    }

    public void Update(string title, string what, string why, DateTime when, string where, string who, string how, decimal howmuch)
    {
        Title = title;
        What = what;
        Why = why;
        When = when;
        Where = where;
        Who = who;
        How = how;
        HowMuch = howmuch;
    }
    
}