using _5W2H.Application.Models;
using _5W2H.Core.Entities;
using MediatR;

namespace _5W2H.Application.Commands.ActionsCommands.StartAction;

public class StartActionCommand : IRequest<ResultViewModel<Acao>>
{
    public StartActionCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}