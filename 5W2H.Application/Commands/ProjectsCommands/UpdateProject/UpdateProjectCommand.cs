using _5W2H.Application.Models;
using _5W2H.Core.Entities;
using MediatR;

namespace _5W2H.Application.Commands.ProjectsCommands.UpdateProject;

public class UpdateProjectCommand : IRequest<ResultViewModel<Project>>
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int ProjectNumber { get; set; }
    public string OriginDate { get; set; }
}