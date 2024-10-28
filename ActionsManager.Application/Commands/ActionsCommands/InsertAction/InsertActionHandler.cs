using _5W2H.Application.Models;
using _5W2H.Core.Repositories;
using MediatR;

namespace _5W2H.Application.Commands.ActionsCommands.InsertAction;

public class InsertActionHandler : IRequestHandler<InsertActionCommand, ResultViewModel<int>>
{
    private readonly IActionRepository _repository;
    private readonly IProjectRepository _projectRepository; 
    private readonly IUserRepository _userRepository;

    public InsertActionHandler(IActionRepository repository, IProjectRepository projectRepository, IUserRepository userRepository)
    {
        _repository = repository;
        _projectRepository = projectRepository;
        _userRepository = userRepository;
    }
    
    
    
    public async Task<ResultViewModel<int>> Handle(InsertActionCommand request, CancellationToken cancellationToken)
    {
        var project = await _projectRepository.GetByIdAsync(request.ProjectId);
        if (project == null)
        {
            return ResultViewModel<int>.Error($"O projeto com ID {request.ProjectId} não existe.");
        }

        var user = await _userRepository.GetByIdAsync(request.UserId);
        if (user == null)
        {
            return ResultViewModel<int>.Error($"O usuário com ID {request.UserId} não existe.");
        }

        var action = request.ToEntity();

        await _repository.AddAsync(action);
        
        return ResultViewModel<int>.Success(action.Id);
    }
}


