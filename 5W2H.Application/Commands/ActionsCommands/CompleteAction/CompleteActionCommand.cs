using _5W2H.Application.Models;
using _5W2H.Core.Entities;
using MediatR;

namespace _5W2H.Application.Commands.ActionsCommands.CompleteAction;

public class CompleteActionCommand : IRequest<ResultViewModel<Acao>>
{
    public CompleteActionCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}