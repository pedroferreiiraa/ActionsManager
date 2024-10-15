using _5W2H.Application.Models;
using MediatR;
using Action = _5W2H.Core.Entities.Action;

namespace _5W2H.Application.Commands.ActionsCommands.StartAction;

public class StartActionCommand : IRequest<ResultViewModel<Action>>
{
    public StartActionCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}