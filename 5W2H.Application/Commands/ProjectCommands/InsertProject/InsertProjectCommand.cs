using _5W2H.Application.Models;
using _5W2H.Core.Entities;
using _5W2H.Core.Enums;
using MediatR;

namespace _5W2H.Application.Commands.ProjectCommands.InsertProject;

public class InsertProjectCommand : IRequest<ResultViewModel<int>>
{
    public string Title { get; set; }
    public string What { get;  set; }
    public string Why { get;  set; }
    public DateTime When { get;  set; }
    public string Where { get; set; }
    public string Who { get; set; }
    public string How { get; set; }
    public decimal HowMuch { get;  set; }
    
    public string Origin { get;  set; }
    public DateTime OriginDate { get;  set; }
    public ProjectStatusEnum Status { get; set; }
    public string ConclusionText { get;  set; }
    
    public Project ToEntity() 
        => new(Title, What, Why, When, Where, Who, How, HowMuch,  Status, Origin, OriginDate, ConclusionText);
}