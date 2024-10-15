using _5W2H.Application.Models;
using _5W2H.Core.Entities;
using MediatR;

namespace _5W2H.Application.Commands.ProjectsCommands.DeleteProject;

public class DeleteProjectCommand : IRequest<ResultViewModel<Project>>
{
    public DeleteProjectCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}