using _5W2H.Application.Models;
using _5W2H.Core.Entities;
using MediatR;

namespace _5W2H.Application.Commands.ProjectCommands.StartProject;

public class StartProjectCommand : IRequest<StartProjectViewModel>
{
    public StartProjectCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}