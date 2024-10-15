using _5W2H.Application.Models;
using _5W2H.Core.Entities;
using MediatR;

namespace _5W2H.Application.Commands.ProjectsCommands.CompleteProject;

public class CompleteProjectCommand : IRequest<ResultViewModel<Project>>
{
    public CompleteProjectCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}