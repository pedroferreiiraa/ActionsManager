using _5W2H.Application.Models;
using MediatR;
using Action = _5W2H.Core.Entities.Action;

namespace _5W2H.Application.Commands.ActionsCommands.DeleteAction;

public class DeleteActionCommand : IRequest<ResultViewModel<Action>>
{
    public DeleteActionCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}