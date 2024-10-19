using _5W2H.Application.Models;
using _5W2H.Core.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace _5W2H.Application.Queries.ProjectQueries.GetAllProjects
{
    public class GetAllProjectsHandler : IRequestHandler<GetAllProjectsQuery, ResultViewModel<List<ProjectViewModel>>>
    {
        private readonly IProjectRepository _projectRepository;

        public GetAllProjectsHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<ResultViewModel<List<ProjectViewModel>>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
        {
            // Aplicar filtro de pesquisa e paginação usando o novo método Query
            var projectsQuery = _projectRepository.Query();

            // Filtro de pesquisa - busca projetos cujo título comece com o termo fornecido
            if (!string.IsNullOrEmpty(request.Search))
            {
                projectsQuery = projectsQuery.Where(p => p.Title.StartsWith(request.Search));
            }

            var totalItems = await projectsQuery.CountAsync(cancellationToken);
            var pagedProjects = await projectsQuery
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync(cancellationToken);

            if (!pagedProjects.Any())
            {
                return ResultViewModel<List<ProjectViewModel>>.Error("Nenhum projeto encontrado.");
            }

            var projectViewModels = pagedProjects.Select(ProjectViewModel.ToEntity).ToList();
            return ResultViewModel<List<ProjectViewModel>>.Success(projectViewModels);
        }


    }
}