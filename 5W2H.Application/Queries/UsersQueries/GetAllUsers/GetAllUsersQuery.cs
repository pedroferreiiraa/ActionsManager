using _5W2H.Application.Models;
using _5W2H.Core.Entities;
using MediatR;

namespace _5W2H.Application.Queries.UsersQueries.GetAllUsers;

public class GetAllUsersQuery : IRequest<ResultViewModel<List<UserViewModel>>>
{
   
}