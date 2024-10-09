using _5W2H.Application.Models;
using _5W2H.Core.Entities;
using _5W2H.Core.Repositories;
using MediatR;

namespace _5W2H.Application.Commands.ProjectCommands.DeleteProject;

public class DeleteProjectHandler : IRequestHandler<DeleteProjectCommand, ResultViewModel<Project>>
{
    
    private readonly IProjectRepository _projectRepository;

    public DeleteProjectHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }
    
    public async Task<ResultViewModel<Project>> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
    {
        var existingProject = await _projectRepository.GetByIdAsync(request.Id);

        if (existingProject == null)
        {
            return ResultViewModel<Project>.Error("Projeto não encontrado");
        }
        
        existingProject.Cancel();
        
        await _projectRepository.SaveChangesAsync();
        return ResultViewModel<Project>.Success(existingProject);
    }
}