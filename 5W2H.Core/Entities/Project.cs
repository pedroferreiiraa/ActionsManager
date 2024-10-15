using _5W2H.Core.Enums;

namespace _5W2H.Core.Entities;

public class Project : BaseEntity
{
    
    public Project(string title, int projectNumber, int userId, ProjectStatusEnum status, string originDate)
    {
        Title = title;
        ProjectNumber = projectNumber;
        UserId = userId;
        Status = status;
        OriginDate = originDate;

        Actions = new List<Action>();
    }

    

    public string Title { get; private set; }
    public int ProjectNumber { get; private set; }
    public ProjectStatusEnum Status { get; private set; }
    public int UserId { get; private set; }
    
    public string OriginDate { get; private set; }
    
    public DateTime? CreatedAt { get; private set; }
    public DateTime? StartedAt { get; private set; }
    public DateTime? CompletedAt { get; private set; }
    public List<Action> Actions { get; set; }
    
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
            StartedAt = DateTime.UtcNow;
        }
    }

    public void Complete()
    {
        if (Status == ProjectStatusEnum.InProgress)
        {
            Status = ProjectStatusEnum.Completed;
            CompletedAt = DateTime.UtcNow;
        }
    }

    public void Update(string title, int projectNumber, string originDate)
    {
        Title = title;
        ProjectNumber = projectNumber;
        OriginDate = originDate;
    }
    
    public void AddAction(Action action)
    {
        Actions.Add(action);
        // Você pode definir a propriedade ProjectId da ação se necessário
        action.ProjectId = this.Id; // Ou o que for apropriado
    }

    public void RemoveAction(Action action)
    {
        Actions.Remove(action);
    }
}