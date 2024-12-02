using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _5W2H.Application.Models;
using _5W2H.Core.Repositories;
using MediatR;

namespace _5W2H.Application.Queries.ProjectQueries.GetProjectsOfUsersDepartment
{
    public class GetProjectsOfUsersDepartmentHandler : IRequestHandler<GetProjectsOfUsersDepartmentQuery, ResultViewModel<List<ProjectViewModel>>>
    {
        private readonly IProjectRepository _repository;

        public GetProjectsOfUsersDepartmentHandler(IProjectRepository repository)
        {
            _repository = repository;
        }


        public async Task<ResultViewModel<List<ProjectViewModel>>> Handle(GetProjectsOfUsersDepartmentQuery request, CancellationToken cancellationToken)
        {
            var projects = await _repository.GetAllProjectsOfDepartment(request.LeaderId);

            if (projects == null || !projects.Any())
            {
                return ResultViewModel<List<ProjectViewModel>>.Error("Nenhum projeto encontrado neste departamento");
            }

            var projectsViewModel = projects
                .Select(ProjectViewModel.ToEntity)
                .ToList();

            return ResultViewModel<List<ProjectViewModel>>.Success(projectsViewModel);
        }
    }
}