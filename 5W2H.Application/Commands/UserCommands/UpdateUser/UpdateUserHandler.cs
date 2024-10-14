using _5W2H.Application.Models;
using _5W2H.Core.Entities;
using _5W2H.Core.Repositories;
using MediatR;

namespace _5W2H.Application.Commands.UserCommands.UpdateUser;

public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, ResultViewModel<int>>
{
    private readonly IUserRepository _userRepository;
    public UpdateUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
        
    }
    
    public async Task<ResultViewModel<int>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        // Obter o usuário pelo ID
        var existingUser = await _userRepository.GetByIdAsync(request.Id);

        // Verificar se o usuário existe
        if (existingUser == null)
        {
            return ResultViewModel<int>.Error("Usuário não encontrado.");
        }

        // Atualizar os dados do usuário
        existingUser.Update(request.FullName, request.Email, request.Role, request.Department);

        // Salvar as mudanças
        await _userRepository.Update(existingUser);

        return ResultViewModel<int>.Success(existingUser.Id);
    }
}