
using _5W2H.Application.Models;
using _5W2H.Application.Queries.ProjectQueries.GetAllProjects;
using MediatR;

namespace _5W2H.Application.Queries.ProjectQueries.GetProjectsOfUsersDepartment
{
    public class GetProjectsOfUsersDepartmentQuery : IRequest<ResultViewModel<PaginatedList<ProjectViewModel>>>
    {
        public GetProjectsOfUsersDepartmentQuery(int departmentId, string search, int pageNumber, int pageSize, int status)
        {
            DepartmentId = departmentId;
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