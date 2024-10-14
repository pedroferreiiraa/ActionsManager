using _5W2H.Application.Models;
using _5W2H.Core.Entities;
using _5W2H.Core.Repositories;
using MediatR;

namespace _5W2H.Application.Commands.ProjectCommands.UpdateProject;

public class UpdateProjectHandler : IRequestHandler<UpdateProjectCommand, ResultViewModel<Project>>
{
    private readonly IProjectRepository _projectRepository;
    public UpdateProjectHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }
    
    public async Task<ResultViewModel<Project>> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
    {
        var existingProject = await _projectRepository.GetByIdAsync(request.Id);
        
        if (existingProject == null)
        {
            
            return ResultViewModel<Project>.Error("Projeto não encontrado.");
        }
        existingProject.Update(request.Title, request.What, request.Why, request.When, request.Where, request.Who, request.How, request.HowMuch, request.Origin, request.OriginDate, request.ConclusionText);
        
        await _projectRepository.SaveChangesAsync();

        return ResultViewModel<Project>.Success(existingProject);
        
    }
}