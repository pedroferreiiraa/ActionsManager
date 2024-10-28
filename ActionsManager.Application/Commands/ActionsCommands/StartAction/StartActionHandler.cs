using _5W2H.Application.Models;
using _5W2H.Core.Entities;
using _5W2H.Core.Repositories;
using MediatR;

namespace _5W2H.Application.Commands.ActionsCommands.StartAction;

public class StartActionHandler : IRequestHandler<StartActionCommand, ResultViewModel<Acao>>
{
    private readonly IActionRepository _actionRepository;

    public StartActionHandler(IActionRepository actionRepository)
    {
        _actionRepository = actionRepository;
    }
    
    public async Task<ResultViewModel<Acao>> Handle(StartActionCommand request, CancellationToken cancellationToken)
    {
        var existingAction = await _actionRepository.GetByIdAsync(request.Id);

        if (existingAction == null)
        {
            
            return ResultViewModel<Acao>.Error("Projeto não encontrado.");
        }
        
        existingAction.Start();

        await _actionRepository.SaveChangesAsync();

        return ResultViewModel<Acao>.Success(existingAction);
    }
}