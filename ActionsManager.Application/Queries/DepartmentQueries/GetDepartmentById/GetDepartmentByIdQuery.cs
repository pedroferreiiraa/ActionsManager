using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _5W2H.Application.Models;
using MediatR;

namespace _5W2H.Application.Queries.DepartmentQueries.GetDepartmentById
{
    public class GetDepartmentByIdQuery : IRequest<ResultViewModel<DepartmentViewModel>>
    {
        public GetDepartmentByIdQuery(int id) 
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}