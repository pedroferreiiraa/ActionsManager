using _5W2H.Application.Models;
using _5W2H.Core.Entities;
using _5W2H.Core.Enums;
using MediatR;

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
    

    public ProjectStatusEnum Status { get; set; }
    public string? ConclusionText { get;  set; }
    public int UserId { get; set; }
    
    public Acao ToEntity() 
        => new(Title, What, Why, When, Where, Who, How, HowMuch,  Status,  ConclusionText, UserId, ProjectId);
}