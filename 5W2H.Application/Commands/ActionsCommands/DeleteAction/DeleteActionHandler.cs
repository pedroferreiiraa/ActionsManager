using _5W2H.Application.Models;
using _5W2H.Core.Entities;
using _5W2H.Core.Repositories;
using MediatR;

namespace _5W2H.Application.Commands.ActionsCommands.DeleteAction;

public class DeleteActionHandler : IRequestHandler<DeleteActionCommand, ResultViewModel<Acao>>
{
    
    private readonly IActionRepository _actionRepository;

    public DeleteActionHandler(IActionRepository actionRepository)
    {
        _actionRepository = actionRepository;
    }
    
    public async Task<ResultViewModel<Acao>> Handle(DeleteActionCommand request, CancellationToken cancellationToken)
    {
        var existingAction = await _actionRepository.GetByIdAsync(request.Id);

        if (existingAction == null)
        {
            return ResultViewModel<Acao>.Error("Action not found");
        }
        
        existingAction.Cancel();
        
        await _actionRepository.SaveChangesAsync();
        return ResultViewModel<Acao>.Success(existingAction);
    }
}