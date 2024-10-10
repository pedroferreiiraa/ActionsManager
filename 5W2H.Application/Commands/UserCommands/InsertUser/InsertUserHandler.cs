
using _5W2H.Core.Repositories;
using _5W2H.Core.Services;
using _5W2H.Infrastructure.AuthServices;
using MediatR;

namespace _5W2H.Application.Commands.UserCommands.InsertUser;


public class InsertUserHandler : IRequestHandler<InsertUserCommand, int>
{
    
    private readonly IUserRepository _userRepository;
    private readonly IAuthService _authService;

    public InsertUserHandler(IUserRepository userRepository, IAuthService authService)
    {
        _userRepository = userRepository;
        _authService = authService;
    }
    
    public async Task<int> Handle(InsertUserCommand request, CancellationToken cancellationToken)
    {
        var passwordHash = _authService.ComputeSha256Hash(request.Password);
        
        var user = request.ToEntity(passwordHash);
        
        await _userRepository.AddAsync(user);
        await _userRepository.SaveChangesAsync();

        return user.Id;

    }
}