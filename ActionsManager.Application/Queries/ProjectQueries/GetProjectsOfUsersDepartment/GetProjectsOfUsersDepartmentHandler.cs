using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _5W2H.Application.Models;
using _5W2H.Application.Queries.ProjectQueries.GetAllProjects;
using _5W2H.Core.Entities;
using _5W2H.Core.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace _5W2H.Application.Queries.ProjectQueries.GetProjectsOfUsersDepartment
{
    public class GetProjectsOfUsersDepartmentHandler : IRequestHandler<GetProjectsOfUsersDepartmentQuery, ResultViewModel<PaginatedList<ProjectViewModel>>>
    {
        private readonly IProjectRepository _repository;

        public GetProjectsOfUsersDepartmentHandler(IProjectRepository repository)
        {
            _repository = repository;
        }


        public async Task<ResultViewModel<PaginatedList<ProjectViewModel>>> Handle(GetProjectsOfUsersDepartmentQuery request, CancellationToken cancellationToken)
        {
            // Buscar projetos dos colaboradores do departamento do líder
            IQueryable<Project> projectsQuery = _repository.Query()
                .Include(p => p.User) // Inclui informações do usuário
                .Where(p => p.User.DepartmentId == request.LeaderId); // Filtro pelo departamento do líder

            // Filtro adicional pelo termo de pesquisa, se fornecido
            if (!string.IsNullOrWhiteSpace(request.Search))
            {
                projectsQuery = projectsQuery.Where(p => 
                    EF.Functions.Like(p.Title, $"%{request.Search}%") || // Nome do projeto
                    EF.Functions.Like(p.Description, $"%{request.Search}%")); // Descrição do projeto
            }

            // Ordenar por data de criação
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
                return ResultViewModel<PaginatedList<ProjectViewModel>>.Error("Nenhum projeto encontrado neste departamento.");
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