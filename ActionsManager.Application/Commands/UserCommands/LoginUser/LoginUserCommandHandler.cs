using _5W2H.Application.Models;
using _5W2H.Core.Repositories;
using _5W2H.Core.Services;
using MediatR;

namespace _5W2H.Application.Commands.UserCommands.LoginUser;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserViewModel>
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthService _authService;
    
    public LoginUserCommandHandler(IUserRepository userRepository, IAuthService authService)
    {
        _userRepository = userRepository;
        _authService = authService;
    }
    
    public async Task<LoginUserViewModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var passwordHash = _authService.ComputeSha256Hash(request.Password);
        
        var user = await _userRepository.GetUserByEmailAndPassword(request.Email, passwordHash);

        if (user == null)
        {
            return null;
        }
        
        var token = _authService.GenerateJwtToken(user.Email, user.Role.ToString(), user.Id);
        
        return new LoginUserViewModel(user.Email, token, user.Id);
    }
}