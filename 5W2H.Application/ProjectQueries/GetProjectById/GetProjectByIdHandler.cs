using _5W2H.Application.Models;
using _5W2H.Core.Repositories;
using MediatR;

namespace _5W2H.Application.ProjectQueries.GetProjectById;

public class GetProjectByIdHandler : IRequestHandler<GetProjectByIdQuery, ResultViewModel<ProjectViewModel>>
{
    private readonly IProjectRepository _repository;

    public GetProjectByIdHandler(IProjectRepository repository)
    {
        _repository = repository;
    }
    
    
    public async Task<ResultViewModel<ProjectViewModel>> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
    {
        var project = await _repository.GetDetailsById(request.Id);

        if (project is null)
        {
            return ResultViewModel<ProjectViewModel>.Error("Projeto não existe");
        }
        
        var model = ProjectViewModel.FromEntity(project);

        return ResultViewModel<ProjectViewModel>.Success(model);
    }
}