using _5W2H.Application.Models;
using _5W2H.Core.Entities;
using _5W2H.Core.Repositories;
using MediatR;

namespace _5W2H.Application.Commands.ProjectsCommands.UpdateConclusionTextProject;

public class UpdateConclusionTextProjectHandler : IRequestHandler<UpdateConclusionTextProjectCommand, ResultViewModel<Project>>
{
    private readonly IProjectRepository _projectRepository;

    public UpdateConclusionTextProjectHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    
    public async Task<ResultViewModel<Project>> Handle(UpdateConclusionTextProjectCommand request, CancellationToken cancellationToken)
    {
       var existingProject = await _projectRepository.GetByIdAsync(request.ProjectId);

       if (existingProject == null)
       {
           return ResultViewModel<Project>.Error("Projeto não encontrado");
       }
       
       existingProject.UpdateConclusionText(request.ConclusionText);
       
       await _projectRepository.UpdateAsync(existingProject);
       
       return ResultViewModel<Project>.Success(existingProject);
       
    }
}