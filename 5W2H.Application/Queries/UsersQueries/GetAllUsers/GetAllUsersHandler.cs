using _5W2H.Application.Models;
using _5W2H.Core.Entities;
using _5W2H.Core.Repositories;
using MediatR;

namespace _5W2H.Application.Queries.UsersQueries.GetAllUsers;

public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, ResultViewModel<List<UserViewModel>>>
{
    private readonly IUserRepository _userRepository;
    public GetAllUsersHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<ResultViewModel<List<UserViewModel>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAllAsync(); 

        if (users == null || !users.Any()) 
        {
            return ResultViewModel<List<UserViewModel>>.Error("Nenhum usuário encontrado.");
        }

        // Mapear os usuários para UserViewModel
        var userViewModels = users.Select(user => new UserViewModel(user)).ToList();

        return ResultViewModel<List<UserViewModel>>.Success(userViewModels);
    }
}