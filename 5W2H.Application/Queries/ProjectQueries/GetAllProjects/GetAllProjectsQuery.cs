using _5W2H.Application.Models;
using _5W2H.Core.Entities;
using MediatR;

namespace _5W2H.Application.Queries.ProjectQueries.GetAllProjects;

public class GetAllProjectsQuery : IRequest<ResultViewModel<List<ProjectViewModel>>>
{
        public string Search { get; set; } = "";
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    
        public GetAllProjectsQuery(string search, int pageNumber, int pageSize)
        {
            Search = search;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
}