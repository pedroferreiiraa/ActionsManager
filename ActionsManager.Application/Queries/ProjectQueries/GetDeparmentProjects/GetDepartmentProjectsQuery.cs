
using _5W2H.Application.Models;
using _5W2H.Application.Queries.ProjectQueries.GetAllProjects;
using MediatR;

namespace _5W2H.Application.Queries.ProjectQueries.GetProjectsOfUsersDepartment
{
    public class GetDepartmentProjectsQuery : IRequest<ResultViewModel<PaginatedList<ProjectViewModel>>>
    {
        public GetDepartmentProjectsQuery(int deparmentId, string search, int pageNumber, int pageSize, int status)
        {
            DepartmentId = deparmentId;
            Search = search;
            PageNumber = pageNumber;
            PageSize = pageSize;
            Status = status;
        }

        public int DepartmentId { get; set;}
        public string Search { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        
        public int Status { get; set; } = -1;
    }
}