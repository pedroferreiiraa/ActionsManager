using _5W2H.Application.Models;
using MediatR;
using Action = _5W2H.Core.Entities.Action;

namespace _5W2H.Application.Commands.ActionsCommands.CompleteAction;

public class CompleteActionCommand : IRequest<ResultViewModel<Action>>
{
    public CompleteActionCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}