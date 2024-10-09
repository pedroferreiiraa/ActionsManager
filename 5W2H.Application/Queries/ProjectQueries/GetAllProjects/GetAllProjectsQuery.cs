using _5W2H.Application.Models;
using MediatR;

namespace _5W2H.Application.Queries.ProjectQueries.GetAllProjects;

public class GetAllProjectsQuery : IRequest<ResultViewModel<List<ProjectViewModel>>> {}
