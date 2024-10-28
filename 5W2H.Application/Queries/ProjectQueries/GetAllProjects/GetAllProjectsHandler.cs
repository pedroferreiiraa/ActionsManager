using _5W2H.Application.Models;
using _5W2H.Core.Entities;
using _5W2H.Core.Enums;
using _5W2H.Core.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq;

namespace _5W2H.Application.Queries.ProjectQueries.GetAllProjects
{
    public class GetAllProjectsHandler : IRequestHandler<GetAllProjectsQuery, ResultViewModel<PaginatedList<ProjectViewModel>>>
    {
        private readonly IProjectRepository _projectRepository;

        public GetAllProjectsHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<ResultViewModel<PaginatedList<ProjectViewModel>>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
        {
            // Start with var to let the compiler infer the correct type
            IQueryable<Project> projectsQuery = _projectRepository.Query().Include(p => p.Actions);


            // Apply filters
            if (request.Status >= 0)
            {
                var projectStatus = (ProjectStatusEnum)request.Status;
                projectsQuery = projectsQuery.Where(p => p.Status == projectStatus);
            }

            if (!string.IsNullOrEmpty(request.Search))
            {
                projectsQuery = projectsQuery.Where(p => p.Title.Contains(request.Search));
            }
            projectsQuery = projectsQuery.OrderByDescending(p => p.CreatedAt);
            
            // Get total count for pagination
            var totalItems = await projectsQuery.CountAsync(cancellationToken);

            // Apply pagination
            var pagedProjects = await projectsQuery
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync(cancellationToken);

            // Check if any projects were found
            if (!pagedProjects.Any())
            {
                return ResultViewModel<PaginatedList<ProjectViewModel>>.Error("Nenhum projeto encontrado.");
            }

            // Map to ViewModel
            var projectViewModels = pagedProjects.Select(ProjectViewModel.ToEntity).ToList();

            // Return paginated list
            return ResultViewModel<PaginatedList<ProjectViewModel>>.Success(
                new PaginatedList<ProjectViewModel>(projectViewModels, totalItems, request.PageNumber, request.PageSize)
            );
        }

    }
}