using _5W2H.Application.Models;
using _5W2H.Core.Entities;
using MediatR;

namespace _5W2H.Application.Commands.ProjectsCommands.UpdateConclusionTextProject;

public class UpdateConclusionTextProjectCommand : IRequest<ResultViewModel<Project>>
{
    public int ProjectId { get; set; }
    public string ConclusionText { get; set; }

    public UpdateConclusionTextProjectCommand(int projectId, string conclusionText)
    {
        ProjectId = projectId;
        ConclusionText = conclusionText;
    }
}