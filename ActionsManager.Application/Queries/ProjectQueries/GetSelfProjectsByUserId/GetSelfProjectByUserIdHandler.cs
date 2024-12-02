using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _5W2H.Application.Models;
using _5W2H.Core.Repositories;
using MediatR;

namespace _5W2H.Application.Queries.ProjectQueries.GetSelfProjectsByUserId
{
    public class GetSelfProjectByUserIdHandler : IRequestHandler<GetSelfProjectByUserID, ResultViewModel<List<ProjectViewModel>>>
    {
        private readonly IProjectRepository _repository;

        public GetSelfProjectByUserIdHandler(IProjectRepository repository) 
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<List<ProjectViewModel>>> Handle(GetSelfProjectByUserID query, CancellationToken cancellationToken)
        {
            if (query == null) throw new ArgumentNullException(nameof(query));

            var projects = await _repository.GetProjectsByUserId(query.UserId);

            if (projects == null || !projects.Any())
            {
                return ResultViewModel<List<ProjectViewModel>>.Error("Nenhum projeto foi encontrado para este colaborador");
            }

            var projectsViewModel = projects
                .Select(ProjectViewModel.ToEntity)
                .ToList();

            return ResultViewModel<List<ProjectViewModel>>.Success(projectsViewModel);

        }
    }
}