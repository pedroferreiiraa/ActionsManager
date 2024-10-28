using _5W2H.Application.Commands.ProjectsCommands.CompleteProject;
using _5W2H.Application.Commands.ProjectsCommands.DeleteProject;
using _5W2H.Application.Commands.ProjectsCommands.InsertProject;
using _5W2H.Application.Commands.ProjectsCommands.InsertProjectAction;
using _5W2H.Application.Commands.ProjectsCommands.StartProject;
using _5W2H.Application.Commands.ProjectsCommands.UpdateConclusionTextProject;
using _5W2H.Application.Commands.ProjectsCommands.UpdateProject;
using _5W2H.Application.Queries.ProjectQueries.GetAllProjects;
using _5W2H.Application.Queries.ProjectQueries.GetProjectById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace _5W2H.Api.Controllers;

[ApiController]
[Route("api/projects")]
public class ProjectController : ControllerBase
{
    private readonly IMediator _mediator;
    public ProjectController(IMediator mediator)
    {
        _mediator = mediator;
            
    }

    [HttpGet]
    public async Task<IActionResult> Get(string search = "", int pageNumber = 1, int pageSize = 10, int status = -1)
    {
        // Criação da query com parâmetros de busca, número da página, tamanho da página e status
        var query = new GetAllProjectsQuery(search, pageNumber, pageSize, status);
        var result = await _mediator.Send(query);

        // Se o resultado for bem-sucedido, retorne a lista de projetos paginada com informações extras
        if (result.IsSuccess)
        {
            return Ok(new
            {
                data = result.Data.Items, // Lista de projetos
                totalItems = result.Data.TotalItems, // Total de projetos encontrados
                totalPages = result.Data.TotalPages, // Número total de páginas
                pageNumber = result.Data.PageNumber, // Página atual
                pageSize = result.Data.PageSize // Tamanho da página
            });
        }
        else
        {
            return BadRequest(result.Message);
        }
    }

    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var query = new GetProjectByIdQuery(id);
        var result = await _mediator.Send(query);

        if (!result.IsSuccess || result.Data == null)
        {
            return NotFound(result.Message);
        }

        return Ok(result.Data);
    }
    
    
    
    [HttpPost]
    public async Task<IActionResult> Post(InsertProjectCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(UpdateProjectCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }
    
    [HttpPut("{id}/start")]
    public async Task<IActionResult> Start(int id, [FromBody] StartProjectCommand command)
    {
        if (command.Id != id)
        {
            return BadRequest(new { message = "O ID no corpo da requisição não coincide com o ID da URL." });
        }
    
        var result = await _mediator.Send(command);
    
        if (!result.IsSuccess)
        {
            return BadRequest(new { message = result.Message });
        }
        
        return Ok(new { isSuccess = true, message = "Projeto iniciado com sucesso." });
    }
    
    [HttpPut("{id}/complete")]
    public async Task<IActionResult> Complete(int id)
    {
        var command = new CompleteProjectCommand(id);
        var result = await _mediator.Send(command);

        if (!result.IsSuccess)
        {
            return BadRequest(new { message = result.Message });
        }
        
        return Ok(new { isSuccess = true, message = "Projeto completado com sucesso." });
    }
    
    [HttpDelete("{id}/delete")]
    public async Task<IActionResult> Delete(DeleteProjectCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }
    
    [HttpPost("{projectId}/actions")]
    public async Task<IActionResult> InsertAction(int projectId, [FromBody] InsertProjectActionCommand command)
    {
        if (command == null)
            return BadRequest("Comando inválido.");

        command.ProjectId = projectId;

        var result = await _mediator.Send(command);
        
        return Ok(result.Data);  
    }

    [HttpPatch("{id}/conclusion")]
    public async Task<IActionResult> PatchConclusion(int id, [FromBody] UpdateConclusionTextProjectCommand command)
    {
        if (id != command.ProjectId)
        {
            return BadRequest("O ID do projeto não corresponde ao fornecido na URL.");
        }

        await _mediator.Send(command);

        return NoContent();
    }
    
}