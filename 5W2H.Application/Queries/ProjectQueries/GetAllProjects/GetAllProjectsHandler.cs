using _5W2H.Application.Models;
using _5W2H.Core.Repositories;
using MediatR;


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
            // Busca todos os projetos, incluindo as ações
            var projects = await _projectRepository.GetAllAsync();

            if (projects == null || !projects.Any())
            {
                return ResultViewModel<List<ProjectViewModel>>.Error("Nenhum projeto encontrado.");
            }

            // Converte cada projeto em ProjectViewModel, retornando apenas os IDs das ações
            var projectViewModels = projects.Select(ProjectViewModel.ToEntity).ToList();

            return ResultViewModel<List<ProjectViewModel>>.Success(projectViewModels);
        }
    }
}