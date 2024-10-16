using _5W2H.Application.Models;
using _5W2H.Core.Entities;
using _5W2H.Core.Repositories;
using MediatR;

namespace _5W2H.Application.Commands.ActionsCommands.UpdateAction;

public class UpdateActionHandler : IRequestHandler<UpdateActionCommand, ResultViewModel<Acao>>
{
    private readonly IActionRepository _actionRepository;
    public UpdateActionHandler(IActionRepository actionRepository)
    {
        _actionRepository = actionRepository;
    }
    
    public async Task<ResultViewModel<Acao>> Handle(UpdateActionCommand request, CancellationToken cancellationToken)
    {
        var existingAction = await _actionRepository.GetByIdAsync(request.Id);
        
        if (existingAction == null)
        {
            
            return ResultViewModel<Acao>.Error("Projeto não encontrado.");
        }
        existingAction.Update(request.Title, request.What, request.Why, request.When, request.Where, request.Who, request.How, request.HowMuch, request.Origin, request.OriginDate, request.ConclusionText);
        
        await _actionRepository.SaveChangesAsync();

        return ResultViewModel<Acao>.Success(existingAction);
        
    }
}