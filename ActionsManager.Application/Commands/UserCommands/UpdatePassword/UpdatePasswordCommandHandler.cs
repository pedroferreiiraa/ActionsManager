using _5W2H.Core.Repositories;
using _5W2H.Core.Services;
using MediatR;

namespace _5W2H.Application.Commands.UserCommands.UpdatePassword
{
    public class UpdatePasswordCommandHandler : IRequestHandler<UpdatePasswordCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;

        public UpdatePasswordCommandHandler(IUserRepository userRepository, IAuthService authService)
        {
            _userRepository = userRepository;
            _authService = authService;
        }

        public async Task<bool> Handle(UpdatePasswordCommand request, CancellationToken cancellationToken)
        {
            // Busca o usuário pelo ID
            var user = await _userRepository.GetByIdAsync(request.UserId);
            if (user == null)
            {
                throw new KeyNotFoundException("Usuário não encontrado.");
            }

            // Verifica a senha atual
            var currentPasswordHash = _authService.ComputeSha256Hash(request.CurrentPassword);
            if (user.Password != currentPasswordHash)
            {
                throw new UnauthorizedAccessException("Senha atual incorreta.");
            }

            // Atualiza a senha
            var newPasswordHash = _authService.ComputeSha256Hash(request.NewPassword);
            user.Password = newPasswordHash;

            // Atualiza o usuário no repositório
            await _userRepository.Update(user);

            return true;
        }
    }
}