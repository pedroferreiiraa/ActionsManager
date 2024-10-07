
using _5W2H.Application.Models;
using _5W2H.Core.Repositories;
using _5W2H.Infrastructure.Persistence;
using MediatR;

namespace _5W2H.Application.ProjectCommands.InsertProject;

public class InsertProjectHandler : IRequestHandler<InsertProjectCommand, ResultViewModel<int>>
{
    private readonly IProjectRepository _repository;

    public InsertProjectHandler(IProjectRepository repository)
    {
        _repository = repository;
    }
    
    
    
    public async Task<ResultViewModel<int>> Handle(InsertProjectCommand request, CancellationToken cancellationToken)
    {
        var project =  request.ToEntity();

        await _repository.Add(project);
        
        return ResultViewModel<int>.Success(project.Id);
    }
}


