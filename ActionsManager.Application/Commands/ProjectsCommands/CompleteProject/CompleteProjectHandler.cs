using _5W2H.Application.Models;
using _5W2H.Core.Entities;
using _5W2H.Core.Repositories;
using MediatR;

namespace _5W2H.Application.Commands.ProjectsCommands.CompleteProject;

public class CompleteProjectHandler : IRequestHandler<CompleteProjectCommand, ResultViewModel<Project>>
{
    
    private readonly IProjectRepository _projectRepository;

    public CompleteProjectHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<ResultViewModel<Project>> Handle(CompleteProjectCommand request, CancellationToken cancellationToken)
    {
        var existingProject = await _projectRepository.GetByIdAsync(request.Id);

        if (existingProject == null)
        {
            return ResultViewModel<Project>.Error("Projeto não encontrado");
        }
        
        existingProject.Complete();
        await _projectRepository.SaveChangesAsync();
        
        return ResultViewModel<Project>.Success(existingProject);
    }
}