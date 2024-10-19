using _5W2H.Application.Models;
using _5W2H.Core.Entities;
using MediatR;

namespace _5W2H.Application.Queries.ProjectQueries.GetAllProjects;

public class GetAllProjectsQuery : IRequest<ResultViewModel<PaginatedList<ProjectViewModel>>>
{
    public string Search { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    
    public int Status { get; set; } = -1;

    public GetAllProjectsQuery(string search, int pageNumber, int pageSize, int status)
    {
        Search = search;
        PageNumber = pageNumber;
        PageSize = pageSize;
        Status = status;
    }
}
