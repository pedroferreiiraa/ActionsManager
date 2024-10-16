using _5W2H.Application.Models;
using _5W2H.Core.Entities;
using MediatR;

namespace _5W2H.Application.Commands.ActionsCommands.DeleteAction;

public class DeleteActionCommand : IRequest<ResultViewModel<Acao>>
{
    public DeleteActionCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}