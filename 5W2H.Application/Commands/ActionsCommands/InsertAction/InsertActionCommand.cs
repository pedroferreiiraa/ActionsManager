using _5W2H.Application.Models;
using _5W2H.Core.Entities;
using _5W2H.Core.Enums;
using MediatR;
using Action = _5W2H.Core.Entities.Action;

namespace _5W2H.Application.Commands.ActionsCommands.InsertAction;

public class InsertActionCommand : IRequest<ResultViewModel<int>>
{
    public int ProjectId { get; set; }
    public string Title { get; set; }
    public string What { get;  set; }
    public string Why { get;  set; }
    public string When { get;  set; }
    public string Where { get; set; }
    public string Who { get; set; }
    public string How { get; set; }
    public decimal HowMuch { get;  set; }
    
    public string Origin { get;  set; }
    public string OriginDate { get;  set; }
    public ProjectStatusEnum Status { get; set; }
    public string ConclusionText { get;  set; }
    public int UserId { get; set; }
    
    public Action ToEntity() 
        => new(Title, What, Why, When, Where, Who, How, HowMuch,  Status, Origin, OriginDate, ConclusionText, UserId, ProjectId);
}