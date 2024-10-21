using _5W2H.Application.Models;
using _5W2H.Core.Entities;
using _5W2H.Core.Repositories;
using MediatR;

namespace _5W2H.Application.Commands.ProjectsCommands.StartProject;

public class StartProjectHandler : IRequestHandler<StartProjectCommand, ResultViewModel<Project>>
{
    private readonly IProjectRepository _projectRepository;

    public StartProjectHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }
    
    public async Task<ResultViewModel<Project>> Handle(StartProjectCommand request, CancellationToken cancellationToken)
    {
        try
        {
            // Usar o método StartAsync do repositório
            var updatedProject = await _projectRepository.StartAsync(request.Id);

            // Retornar o projeto atualizado como JSON
            return ResultViewModel<Project>.Success(updatedProject);
        }
        catch (InvalidOperationException ex)
        {
            // Retornar erro em um formato que o frontend possa interpretar
            return ResultViewModel<Project>.Error(ex.Message);
        }
        catch (Exception ex)
        {
            return ResultViewModel<Project>.Error($"Erro desconhecido: {ex.Message}");
        }
    }
}