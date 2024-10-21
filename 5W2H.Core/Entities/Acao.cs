// File: _5W2H.Core/Entities/Action.cs
using System.Text.Json.Serialization;
using _5W2H.Core.Enums;

namespace _5W2H.Core.Entities;

public class Acao : BaseEntity
{
    public Acao(string title, string what, string why, string when, string where, string who, string how,
                  decimal howMuch, ProjectStatusEnum status, string origin, string originDate, 
                  string conclusionText, int userId, int projectId)
    {
        Title = title;
        What = what;
        Why = why;
        When = when;
        Where = where;
        Who = who;
        How = how;
        HowMuch = howMuch;
        Status = status;
        Origin = origin;
        OriginDate = originDate;
        ConclusionText = conclusionText;
        UserId = userId;
        ProjectId = projectId;
    }

    public string Title { get; private set; }
    public string What { get; private set; }
    public string Why { get; private set; }
    public string When { get; private set; }
    public string Where { get; private set; }
    public string Who { get; private set; }
    public string How { get; private set; }
    public decimal HowMuch { get; private set; }
    public ProjectStatusEnum Status { get; private set; }

    public int UserId { get; private set; }
    public User User { get; private set; }
    public virtual Project Project { get; private set; }
    public string Origin { get; private set; }
    public string OriginDate { get; private set; }
    public string ConclusionText { get; private set; }

    public int ProjectId { get; private set; }  // Apenas ID do projeto, sem referência ao objeto completo.
    public DateTime? StartedAt { get; private set; }
    public DateTime? CompletedAt { get; private set; }

    
    
    public void SetProjectId(int projectId)
    {
        ProjectId = projectId;
    }
    
    public void Cancel()
    {
        if (Status == ProjectStatusEnum.InProgress || Status == ProjectStatusEnum.Suspended)
            Status = ProjectStatusEnum.Cancelled;
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


    // Atualiza as informações da ação
    public void Update(string title, string what, string why, string when, string where, string who,
                       string how, decimal howMuch, string origin, string originDate, string conclusionText)
    {
        Title = title;
        What = what;
        Why = why;
        When = when;
        Where = where;
        Who = who;
        How = how;
        HowMuch = howMuch;
        Origin = origin;
        OriginDate = originDate;
        ConclusionText = conclusionText;
    }
}
