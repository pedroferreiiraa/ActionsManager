using _5W2H.Application.Models;
using _5W2H.Core.Repositories;
using MediatR;

namespace _5W2H.Application.Commands.DepartmentCommands.InsertDepartment;

public class InsertDepartmentHandler : IRequestHandler<InsertDepartmentCommand, ResultViewModel<int>>
{
    private readonly IDepartmentRepository _repository;

    public InsertDepartmentHandler(IDepartmentRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<ResultViewModel<int>> Handle(InsertDepartmentCommand request, CancellationToken cancellationToken)
    {
        var departament = request.ToEntity();

        await _repository.AddAsync(departament);
        
        return ResultViewModel<int>.Success(departament.Id);
    }
}