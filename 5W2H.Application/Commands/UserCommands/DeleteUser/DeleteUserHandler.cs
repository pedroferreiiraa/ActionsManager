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
        var existingUser =  await _userRepository.GetByIdAsync(request.Id);

        existingUser.SetAsDeleted();
        await _userRepository.SaveChangesAsync();
        return ResultViewModel<int>.Success(existingUser.Id);
    }
}