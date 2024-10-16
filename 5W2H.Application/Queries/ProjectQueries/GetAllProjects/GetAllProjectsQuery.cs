using _5W2H.Application.Models;
using _5W2H.Core.Entities;
using MediatR;

namespace _5W2H.Application.Queries.ProjectQueries.GetAllProjects;

public class GetAllProjectsQuery : IRequest<ResultViewModel<List<ProjectViewModel>>>
{
    
}