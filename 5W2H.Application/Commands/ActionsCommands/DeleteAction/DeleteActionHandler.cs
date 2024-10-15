using _5W2H.Application.Models;
using _5W2H.Core.Repositories;
using MediatR;
using Action = _5W2H.Core.Entities.Action;

namespace _5W2H.Application.Commands.ActionsCommands.DeleteAction;

public class DeleteActionHandler : IRequestHandler<DeleteActionCommand, ResultViewModel<Action>>
{
    
    private readonly IActionRepository _actionRepository;

    public DeleteActionHandler(IActionRepository actionRepository)
    {
        _actionRepository = actionRepository;
    }
    
    public async Task<ResultViewModel<Action>> Handle(DeleteActionCommand request, CancellationToken cancellationToken)
    {
        var existingAction = await _actionRepository.GetByIdAsync(request.Id);

        if (existingAction == null)
        {
            return ResultViewModel<Action>.Error("Action not found");
        }
        
        existingAction.Cancel();
        
        await _actionRepository.SaveChangesAsync();
        return ResultViewModel<Action>.Success(existingAction);
    }
}