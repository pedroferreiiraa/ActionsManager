using _5W2H.Application.Models;
using _5W2H.Core.Repositories;
using MediatR;

namespace _5W2H.Application.Commands.ProjectsCommands.InsertProject;

public class InsertProjectHandler : IRequestHandler<InsertProjectCommand, ResultViewModel<int>>
{
    private readonly IProjectRepository _repository;

    public InsertProjectHandler(IProjectRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<ResultViewModel<int>> Handle(InsertProjectCommand request, CancellationToken cancellationToken)
    {
        var project = request.ToEntity();
        
        await _repository.AddAsync(project);
        
        return new ResultViewModel<int>(project.Id);
        
    }
}