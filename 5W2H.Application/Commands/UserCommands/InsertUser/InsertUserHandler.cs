using _5W2H.Core.Entities;
using _5W2H.Core.Repositories;
using MediatR;

namespace _5W2H.Application.Commands.UserCommands.InsertUser;

public class InsertUserHandler : IRequestHandler<InsertUserCommand, int>
{
    
    private readonly IUserRepository _userRepository;

    public InsertUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<int> Handle(InsertUserCommand request, CancellationToken cancellationToken)
    {
        var user = request.ToEntity();
        await _userRepository.AddAsync(user);
        await _userRepository.SaveChangesAsync();

        return user.Id;

    }
}