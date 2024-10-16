using _5W2H.Application.Models;
using _5W2H.Core.Entities;
using _5W2H.Core.Repositories;
using MediatR;

namespace _5W2H.Application.Commands.ActionsCommands.CompleteAction;

public class CompleteActiontHandler : IRequestHandler<CompleteActionCommand, ResultViewModel<Acao>>
{
    private readonly IActionRepository _actionRepository;

    public CompleteActiontHandler(IActionRepository actionRepository)
    {
        _actionRepository = actionRepository;
    }
    
    public async Task<ResultViewModel<Acao>> Handle(CompleteActionCommand request, CancellationToken cancellationToken)
    {
        var existingAction = await _actionRepository.GetByIdAsync(request.Id);

        if (existingAction == null)
        {
            
            return ResultViewModel<Acao>.Error("Projeto não encontrado.");
        }

        existingAction.Complete();

        await _actionRepository.SaveChangesAsync();

        return ResultViewModel<Acao>.Success(existingAction);
    }
}