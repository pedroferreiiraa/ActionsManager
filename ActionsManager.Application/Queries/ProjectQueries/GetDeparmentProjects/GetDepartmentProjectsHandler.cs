using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _5W2H.Application.Models;
using _5W2H.Application.Queries.ProjectQueries.GetAllProjects;
using _5W2H.Core.Entities;
using _5W2H.Core.Enums;
using _5W2H.Core.Repositories;
using _5W2H.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace _5W2H.Application.Queries.ProjectQueries.GetProjectsOfUsersDepartment
{
    public class GetDepartmentProjectsHandler : IRequestHandler<GetDepartmentProjectsQuery,
        ResultViewModel<PaginatedList<ProjectViewModel>>>
    {
        private readonly IProjectRepository _repository;


        public GetDepartmentProjectsHandler(IProjectRepository repository)
        {
            _repository = repository;
        }


        public async Task<ResultViewModel<PaginatedList<ProjectViewModel>>> Handle(GetDepartmentProjectsQuery request,
            CancellationToken cancellationToken)
        {
            // Buscar projetos dos colaboradores do departamento específico
            IQueryable<Project> projectsQuery = _repository.Query()
                .Include(p => p.Actions)
                .Include(p => p.User) // Incluir informações do usuário
                .Where(p => p.User.DepartmentId == request.DepartmentId && !p.IsDeleted); // Filtra pelo DepartmentId

            // Filtro por status, se fornecido
            if (request.Status >= 0)
            {
                var projectStatus = (ProjectStatusEnum)request.Status;
                projectsQuery = projectsQuery.Where(p => p.Status == projectStatus);
            }

            // Filtro por termo de pesquisa, se fornecido
            if (!string.IsNullOrEmpty(request.Search))
            {
                projectsQuery = projectsQuery.Where(p => p.Title.Contains(request.Search));
            }

            // Ordenar por data de criação (do mais recente para o mais antigo)
            projectsQuery = projectsQuery.OrderByDescending(p => p.CreatedAt);

            // Contar o total de itens para paginação
            var totalItems = await projectsQuery.CountAsync(cancellationToken);

            // Aplicar a paginação
            var paginatedProjects = await projectsQuery
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync(cancellationToken);

            // Se não houver projetos, retornar erro
            if (!paginatedProjects.Any())
            {
                return ResultViewModel<PaginatedList<ProjectViewModel>>.Error(
                    "Nenhum projeto encontrado neste departamento.");
            }

            // Mapear para o ViewModel
            var projectViewModels = paginatedProjects
                .Select(ProjectViewModel.ToEntity)
                .ToList();

            // Retornar lista paginada
            return ResultViewModel<PaginatedList<ProjectViewModel>>.Success(
                new PaginatedList<ProjectViewModel>(projectViewModels, totalItems, request.PageNumber, request.PageSize)
            );
        }
    }
}
