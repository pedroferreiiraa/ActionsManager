using _5W2H.Application.Models;
using _5W2H.Core.Repositories;
using MediatR;

namespace _5W2H.Application.Queries.ActionQueries.GetActionById;

public class GetActionByIdHandler : IRequestHandler<GetActionByIdQuery, ResultViewModel<ActionDetailsViewModel>>
{
    private readonly IActionRepository _repository;

    public GetActionByIdHandler(IActionRepository repository)
    {
        _repository = repository;
    }
    
    
    public async Task<ResultViewModel<ActionDetailsViewModel>> Handle(GetActionByIdQuery request, CancellationToken cancellationToken)
    {
        var project = await _repository.GetByIdAsync(request.Id);

        var model = ActionDetailsViewModel.FromEntity(project);

        return ResultViewModel<ActionDetailsViewModel>.Success(model);
    }
}