using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _5W2H.Application.Models;
using MediatR;

namespace _5W2H.Application.Queries.ProjectQueries.GetSelfProjectsByUserId
{
    public class GetSelfProjectByUserID : IRequest<ResultViewModel<List<ProjectViewModel>>>
    {
        public GetSelfProjectByUserID(int userId)
        {
            UserId = userId;
        }

        public int UserId { get; set;}
    }
}