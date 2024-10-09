using _5W2H.Application.Models;
using _5W2H.Core.Repositories;
using MediatR;

namespace _5W2H.Application.Commands.ProjectCommands.StartProject;

public class StartProjectHandler : IRequestHandler<StartProjectCommand, StartProjectViewModel>
{
    private readonly IProjectRepository _projectRepository;

    public StartProjectHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }
    
    public async Task<StartProjectViewModel> Handle(StartProjectCommand request, CancellationToken cancellationToken)
    {
        var existingProject = await _projectRepository.GetByIdAsync(request.Id);

        if (existingProject == null)
        {
            return new StartProjectViewModel
            {
                Success = false,
                Message = "Projeto não encontrado. "
            };
            
        }
        existingProject.Start();

        await _projectRepository.SaveChangesAsync();

        return new StartProjectViewModel
        {
            Success = true,
            Message = "Projeto iniciado com sucesso. ",
            Project = existingProject
        };
    }
}