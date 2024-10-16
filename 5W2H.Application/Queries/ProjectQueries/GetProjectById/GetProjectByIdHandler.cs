using _5W2H.Application.Models;
using _5W2H.Core.Repositories;
using MediatR;

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
        var project = await _projectRepository.GetByIdAsync(request.Id);
        
        return ResultViewModel<ProjectViewModel>.Success(ProjectViewModel.ToEntity(project));
        
    }
}