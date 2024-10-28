using _5W2H.Application.Models;
using _5W2H.Core.Entities;
using _5W2H.Core.Repositories;
using MediatR;

namespace _5W2H.Application.Commands.ProjectsCommands.DeleteProject;

public class DeleteProjectHandler : IRequestHandler<DeleteProjectCommand, ResultViewModel<int>>
{
    private readonly IProjectRepository _projectRepository;

    public DeleteProjectHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    
    public async Task<ResultViewModel<int>> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
    {
        var existingProject = await _projectRepository.GetByIdAsync(request.Id);
        
        if (existingProject == null)
        {
            return ResultViewModel<int>.Error("Projeto não encontrado");
        }
        
        await _projectRepository.DeleteAsync(request.Id);
        
        return ResultViewModel<int>.Success(request.Id);
    }
}