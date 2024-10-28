using _5W2H.Application.Models;
using MediatR;

namespace _5W2H.Application.Queries.ProjectQueries.GetProjectById;

public class GetProjectByIdQuery : IRequest<ResultViewModel<ProjectViewModel>>
{
    public GetProjectByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}