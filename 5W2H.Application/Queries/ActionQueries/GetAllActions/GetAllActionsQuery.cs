using _5W2H.Application.Models;
using MediatR;

namespace _5W2H.Application.Queries.ActionQueries.GetAllActions;

public class GetAllActionsQuery : IRequest<ResultViewModel<List<ActionViewModel>>> {}
