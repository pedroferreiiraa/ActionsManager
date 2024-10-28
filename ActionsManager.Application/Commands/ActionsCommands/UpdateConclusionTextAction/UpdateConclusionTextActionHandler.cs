using _5W2H.Application.Models;
using _5W2H.Core.Entities;
using _5W2H.Core.Repositories;
using MediatR;

namespace _5W2H.Application.Commands.ActionsCommands.UpdateConclusionTextAction;

public class UpdateConclusionTextActionHandler : IRequestHandler<UpdateConclusionTextActionCommand, ResultViewModel<Acao>>
{
    private readonly IActionRepository _actionRepository;

    public UpdateConclusionTextActionHandler(IActionRepository actionRepository)
    {
        _actionRepository = actionRepository;
    }
    
    public async Task<ResultViewModel<Acao>> Handle(UpdateConclusionTextActionCommand request, CancellationToken cancellationToken)
    {
        var existingAction = await _actionRepository.GetByIdAsync(request.ActionId);

        if (existingAction == null)
        {
            return ResultViewModel<Acao>.Error("Ação não encontrada");
        }
        
        existingAction.UpdateConclusionText(request.ConclusionText);
        
        await _actionRepository.UpdateAsync(existingAction);
        
        return ResultViewModel<Acao>.Success(existingAction);
        
    }
}