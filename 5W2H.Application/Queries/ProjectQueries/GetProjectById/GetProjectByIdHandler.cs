using _5W2H.Application.Models;
using _5W2H.Core.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace _5W2H.Application.Queries.ProjectQueries.GetProjectById;

public class GetProjectByIdHandler : IRequestHandler<GetProjectByIdQuery, ResultViewModel<ProjectViewModel>>
{
    private readonly IProjectRepository _projectRepository;

    public GetProjectByIdHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }
    
    
    
    public async Task<ResultViewModel<ProjectViewModel>> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
    {
        var project = await _projectRepository.Query()
            .Include(p => p.Actions)
            .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

        if (project == null)
        {
            return ResultViewModel<ProjectViewModel>.Error("Projeto não encontrado.");
        }

        // Log para verificar se as ações estão sendo carregadas
        var actionCount = project.Actions?.Count ?? 0;
        Console.WriteLine($"Projeto ID {project.Id} possui {actionCount} ações.");

        return ResultViewModel<ProjectViewModel>.Success(ProjectViewModel.ToEntity(project));
    }
}