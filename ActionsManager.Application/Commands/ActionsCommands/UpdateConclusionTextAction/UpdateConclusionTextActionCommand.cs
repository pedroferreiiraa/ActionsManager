using _5W2H.Application.Models;
using _5W2H.Core.Entities;
using MediatR;

namespace _5W2H.Application.Commands.ActionsCommands.UpdateConclusionTextAction;

public class UpdateConclusionTextActionCommand : IRequest<ResultViewModel<Acao>>
{
    public int ActionId { get; set; }
    public string ConclusionText { get; set; }

    public UpdateConclusionTextActionCommand(int actionId, string conclusionText)
    {
        ActionId = actionId;
        ConclusionText = conclusionText;
    }
}