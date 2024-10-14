using _5W2H.Application.Models;
using _5W2H.Core.Repositories;
using MediatR;

namespace _5W2H.Application.Queries.ProjectQueries.GetAllProjects;

public class GetAllProjectsHandler : IRequestHandler<GetAllProjectsQuery, ResultViewModel<List<ProjectViewModel>>>
{
    private readonly IProjectRepository _repository;
    public GetAllProjectsHandler(IProjectRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<ResultViewModel<List<ProjectViewModel>>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
    {
        var projects = await _repository.GetAllAsync();
        
        var model = projects.Select(ProjectViewModel.FromEntity).ToList();
        
        return ResultViewModel<List<ProjectViewModel>>.Success(model);
    }
}