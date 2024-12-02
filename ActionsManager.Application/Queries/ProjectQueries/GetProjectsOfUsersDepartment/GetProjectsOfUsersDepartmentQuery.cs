using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _5W2H.Application.Models;
using MediatR;

namespace _5W2H.Application.Queries.ProjectQueries.GetProjectsOfUsersDepartment
{
    public class GetProjectsOfUsersDepartmentQuery : IRequest<ResultViewModel<List<ProjectViewModel>>>
    {
        public GetProjectsOfUsersDepartmentQuery(int leaderId)
        {
            LeaderId = leaderId;
        }

        public int LeaderId { get; set;}
    }
}