using _5W2H.Application.Models;
using _5W2H.Core.Repositories;
using MediatR;

namespace _5W2H.Application.Queries.ProjectQueries.GetProjectById;

public class GetProjectByIdHandler : IRequestHandler<GetProjectByIdQuery, ResultViewModel<ProjectViewModel>>
{
    private readonly IProjectRepository _repository;

    public GetProjectByIdHandler(IProjectRepository repository)
    {
        _repository = repository;
    }
    
    
    public async Task<ResultViewModel<ProjectViewModel>> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
    {
        var project = await _repository.GetByIdAsync(request.Id);

        var model = ProjectViewModel.FromEntity(project);

        return ResultViewModel<ProjectViewModel>.Success(model);
    }
}