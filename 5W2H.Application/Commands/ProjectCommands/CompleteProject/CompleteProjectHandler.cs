using _5W2H.Application.Models;
using _5W2H.Core.Repositories;
using MediatR;

namespace _5W2H.Application.Commands.ProjectCommands.CompleteProject;

public class CompleteProjectHandler : IRequestHandler<CompleteProjectCommand, CompleteProjectViewModel>
{
    private readonly IProjectRepository _projectRepository;

    public CompleteProjectHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }
    
    public async Task<CompleteProjectViewModel> Handle(CompleteProjectCommand request, CancellationToken cancellationToken)
    {
        var existingProject = await _projectRepository.GetByIdAsync(request.Id);

        if (existingProject == null)
        {
            return new CompleteProjectViewModel
            {
                Success = false,
                Message = "Projeto não encontrado. "
            };
            
        }
        existingProject.Complete();

        await _projectRepository.SaveChangesAsync();

        return new CompleteProjectViewModel
        {
            Success = true,
            Message = "Projeto concluído com sucesso. ",
            Project = existingProject
        };
    }
}