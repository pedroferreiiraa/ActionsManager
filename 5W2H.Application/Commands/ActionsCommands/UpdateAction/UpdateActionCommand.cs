using _5W2H.Application.Models;
using _5W2H.Core.Entities;
using MediatR;

namespace _5W2H.Application.Commands.ActionsCommands.UpdateAction;

public class UpdateActionCommand : IRequest<ResultViewModel<Acao>>
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string What { get;  set; }
    public string Why { get;  set; }
    public string When { get;  set; }
    public string Where { get;  set; }
    public string Who { get;  set; }
    public string How { get;  set; }
    public decimal HowMuch { get;  set; }
    public string Origin { get;  set; }
    public string OriginDate { get;  set; }
    public string ConclusionText { get; set; }
}