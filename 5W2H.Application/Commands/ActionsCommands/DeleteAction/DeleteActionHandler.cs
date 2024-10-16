using _5W2H.Application.Models;
using _5W2H.Core.Entities;
using _5W2H.Core.Repositories;
using MediatR;

namespace _5W2H.Application.Commands.ActionsCommands.DeleteAction;

public class DeleteActionHandler : IRequestHandler<DeleteActionCommand, ResultViewModel<int>>
{
    
    private readonly IActionRepository _actionRepository;

    public DeleteActionHandler(IActionRepository actionRepository)
    {
        _actionRepository = actionRepository;
    }
    
    public async Task<ResultViewModel<int>> Handle(DeleteActionCommand request, CancellationToken cancellationToken)
    {
        var existingAction = await _actionRepository.GetByIdAsync(request.Id);

        if (existingAction == null)
        {
            return ResultViewModel<int>.Error("Ação não encontrada");
        }
       
        await _actionRepository.DeleteAsync(request.Id);
        
        return ResultViewModel<int>.Success(request.Id);
    }
}