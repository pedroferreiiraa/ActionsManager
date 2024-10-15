using _5W2H.Application.Models;
using _5W2H.Core.Repositories;
using MediatR;
using Action = _5W2H.Core.Entities.Action;

namespace _5W2H.Application.Commands.ActionsCommands.UpdateAction;

public class UpdateActionHandler : IRequestHandler<UpdateActionCommand, ResultViewModel<Action>>
{
    private readonly IActionRepository _actionRepository;
    public UpdateActionHandler(IActionRepository actionRepository)
    {
        _actionRepository = actionRepository;
    }
    
    public async Task<ResultViewModel<Action>> Handle(UpdateActionCommand request, CancellationToken cancellationToken)
    {
        var existingAction = await _actionRepository.GetByIdAsync(request.Id);
        
        if (existingAction == null)
        {
            
            return ResultViewModel<Action>.Error("Projeto não encontrado.");
        }
        existingAction.Update(request.Title, request.What, request.Why, request.When, request.Where, request.Who, request.How, request.HowMuch, request.Origin, request.OriginDate, request.ConclusionText);
        
        await _actionRepository.SaveChangesAsync();

        return ResultViewModel<Action>.Success(existingAction);
        
    }
}