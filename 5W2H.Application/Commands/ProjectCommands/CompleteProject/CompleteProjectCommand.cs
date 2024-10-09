using _5W2H.Application.Models;
using MediatR;

namespace _5W2H.Application.Commands.ProjectCommands.CompleteProject;

public class CompleteProjectCommand : IRequest<CompleteProjectViewModel>
{
    public CompleteProjectCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}