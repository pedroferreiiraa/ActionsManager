using System.Runtime.InteropServices.JavaScript;
using _5W2H.Application.Models;
using _5W2H.Core.Entities;
using _5W2H.Core.Repositories;
using MediatR;

namespace _5W2H.Application.Commands.UserCommands.DeleteUser;

public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, ResultViewModel<int>>
{
    private readonly IUserRepository _userRepository;
    public DeleteUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
        
    }

    public async Task<ResultViewModel<int>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var existingUser = await _userRepository.GetByIdAsync(request.Id);

            if (existingUser == null)
            {
                return ResultViewModel<int>.Error("Usuário não encontrado");
            }

            await _userRepository.DeleteAsync(request.Id);

            return ResultViewModel<int>.Success(request.Id);
        }
        catch (Exception ex)
        {
            // Log the exception and return an appropriate error message
            return ResultViewModel<int>.Error("Erro ao deletar usuário: " + ex.Message);
        }
    }
}