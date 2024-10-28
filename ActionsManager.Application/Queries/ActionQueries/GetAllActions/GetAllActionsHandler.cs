using _5W2H.Application.Models;
using _5W2H.Core.Repositories;
using MediatR;

namespace _5W2H.Application.Queries.ActionQueries.GetAllActions;

public class GetAllActionsHandler : IRequestHandler<GetAllActionsQuery, ResultViewModel<List<ActionViewModel>>>
{
    private readonly IActionRepository _repository;
    public GetAllActionsHandler(IActionRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<ResultViewModel<List<ActionViewModel>>> Handle(GetAllActionsQuery request, CancellationToken cancellationToken)
    {
        var projects = await _repository.GetAllAsync();
        
        var model = projects.Select(ActionViewModel.FromEntity).ToList();
        
        return ResultViewModel<List<ActionViewModel>>.Success(model);
    }
}