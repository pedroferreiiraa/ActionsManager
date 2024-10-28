using _5W2H.Application.Models;
using _5W2H.Core.Entities;
using _5W2H.Core.Enums;
using MediatR;

namespace _5W2H.Application.Commands.ProjectsCommands.InsertProject;

public class InsertProjectCommand : IRequest<ResultViewModel<int>>
{
    public string Title { get; set; }
  
    public int UserId { get; set; }
    public ProjectStatusEnum Status { get; set; }
    public string OriginDate { get; set; }
    public string Description { get; set; }
    public string Origin { get; set; }
    public int OriginNumber { get; set; }
    public string? ConclusionText { get; set; }
    
    public Project ToEntity()
        => new(Title,  UserId, Status, OriginDate, Description, Origin, OriginNumber, ConclusionText);
    
}