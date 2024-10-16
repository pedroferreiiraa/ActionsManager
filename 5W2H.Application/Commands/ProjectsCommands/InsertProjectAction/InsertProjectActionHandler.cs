using _5W2H.Application.Models;
using _5W2H.Core.Entities;
using _5W2H.Core.Repositories;
using MediatR;

namespace _5W2H.Application.Commands.ProjectsCommands.InsertProjectAction;

public class InsertProjectActionHandler : IRequestHandler<InsertProjectActionCommand, ResultViewModel<Project>>
{
    private readonly IProjectRepository _projectRepository;
    private readonly IActionRepository _actionRepository; 

    public InsertProjectActionHandler(IProjectRepository projectRepository, IActionRepository actionRepository) 
    {
        _projectRepository = projectRepository ?? throw new ArgumentNullException(nameof(projectRepository));
        _actionRepository = actionRepository ?? throw new ArgumentNullException(nameof(actionRepository));
    }

    public async Task<ResultViewModel<Project>> Handle(InsertProjectActionCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var project = await _projectRepository.GetByIdWithActionsAsync(request.ProjectId);
            if (project == null)
            {
                return ResultViewModel<Project>.Error("Projeto não encontrado.");
            }

            var action = await _actionRepository.GetByIdAsync(request.ActionId);
            if (action == null)
            {
                return ResultViewModel<Project>.Error("Ação não encontrada.");
            }

            // Verifica se a ação já está associada ao projeto
            if (project.Actions.Any(a => a.Id == action.Id))
            {
                return ResultViewModel<Project>.Error("Ação já está associada a este projeto.");
            }

            project.AddAction(action);
            await _projectRepository.SaveChangesAsync();
            
            return new ResultViewModel<Project>(project); // Retorna o projeto atualizado
        }
        catch (Exception ex)
        {
            // Log da exceção (não implementado aqui)
            return ResultViewModel<Project>.Error("Ocorreu um erro ao adicionar a ação ao projeto.");
        }
    }
}