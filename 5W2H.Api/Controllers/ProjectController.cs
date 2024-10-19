using _5W2H.Application.Commands.ProjectsCommands.CompleteProject;
using _5W2H.Application.Commands.ProjectsCommands.DeleteProject;
using _5W2H.Application.Commands.ProjectsCommands.InsertProject;
using _5W2H.Application.Commands.ProjectsCommands.InsertProjectAction;
using _5W2H.Application.Commands.ProjectsCommands.StartProject;
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
    public async Task<IActionResult> Get(string search = "", int pageNumber = 1, int pageSize = 5)
    {
        // Criação da query com parâmetros de busca, número da página e tamanho da página
        var query = new GetAllProjectsQuery(search, pageNumber, pageSize);
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
        
        var project = await _mediator.Send(query);

        if (project == null)
        {
            return NotFound();
        }
        
        return Ok(project);
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
    public async Task<IActionResult> Start(StartProjectCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }
    
    [HttpPut("{id}/complete")]
    public async Task<IActionResult> Complete(CompleteProjectCommand command)
    {        
        await _mediator.Send(command);
        return NoContent();
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

    
    
}