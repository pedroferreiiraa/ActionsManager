using _5W2H.Application.Models;
using _5W2H.Core.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

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
            var projectsQuery = _projectRepository.Query();

            if (!string.IsNullOrEmpty(request.Search))
            {
                projectsQuery = projectsQuery.Where(p => p.Title.ToLower().StartsWith(request.Search.ToLower()));
            }

            var totalItems = await projectsQuery.CountAsync(cancellationToken);
            var pagedProjects = await projectsQuery
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync(cancellationToken);

            if (!pagedProjects.Any())
            {
                return ResultViewModel<PaginatedList<ProjectViewModel>>.Error("Nenhum projeto encontrado.");
            }

            var projectViewModels = pagedProjects.Select(ProjectViewModel.ToEntity).ToList();

            // Criar a lista paginada com as informações necessárias
            var paginatedList = new PaginatedList<ProjectViewModel>(projectViewModels, totalItems, request.PageNumber, request.PageSize);

            // Retornar o ResultViewModel com a lista paginada
            return ResultViewModel<PaginatedList<ProjectViewModel>>.Success(paginatedList);
        }
    }
}