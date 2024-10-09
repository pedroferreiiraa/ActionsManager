using _5W2H.Application.Models;
using _5W2H.Core.Repositories;
using MediatR;

namespace _5W2H.Application.Queries.ProjectQueries.GetProjectById;

public class GetProjectByIdHandler : IRequestHandler<GetProjectByIdQuery, ResultViewModel<ProjectDetailsViewModel>>
{
    private readonly IProjectRepository _repository;

    public GetProjectByIdHandler(IProjectRepository repository)
    {
        _repository = repository;
    }
    
    
    public async Task<ResultViewModel<ProjectDetailsViewModel>> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
    {
        var project = await _repository.GetByIdAsync(request.Id);

        var model = ProjectDetailsViewModel.FromEntity(project);

        return ResultViewModel<ProjectDetailsViewModel>.Success(model);
    }
}