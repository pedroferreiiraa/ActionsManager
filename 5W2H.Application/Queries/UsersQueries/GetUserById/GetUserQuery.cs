using _5W2H.Application.Models;
using MediatR;

namespace _5W2H.Application.Queries.UsersQueries.GetUserById;

public class GetUserQuery : IRequest<UserViewModel>
{
    public GetUserQuery(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}