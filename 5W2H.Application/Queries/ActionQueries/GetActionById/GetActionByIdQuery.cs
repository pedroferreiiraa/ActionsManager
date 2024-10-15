using _5W2H.Application.Models;
using MediatR;

namespace _5W2H.Application.Queries.ActionQueries.GetActionById;

public class GetActionByIdQuery :IRequest<ResultViewModel<ActionDetailsViewModel>>
{
    public GetActionByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}