using _5W2H.Application.Models;
using _5W2H.Core.Repositories;
using MediatR;

namespace _5W2H.Application.Queries.DepartmentQueries.GetAllDepartments;

public class GetAllDepartmentsHandler : IRequestHandler<GetAllDepartmentsQuery, ResultViewModel<List<DepartmentViewModel>>>
{
    private readonly IDepartmentRepository _repository;

    public GetAllDepartmentsHandler(IDepartmentRepository repository)
    {
        _repository = repository;
    }
    
    
    public async Task<ResultViewModel<List<DepartmentViewModel>>> Handle(GetAllDepartmentsQuery request, CancellationToken cancellationToken)
    {
        var departments = await _repository.GetAllAsync();

        var model = departments.Select(DepartmentViewModel.FromEntity).ToList();
       
        return ResultViewModel<List<DepartmentViewModel>>.Success(model);
    }
}