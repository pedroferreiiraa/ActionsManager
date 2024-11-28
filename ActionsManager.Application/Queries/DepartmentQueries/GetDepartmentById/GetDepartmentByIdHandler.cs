using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _5W2H.Application.Models;
using _5W2H.Core.Repositories;
using MediatR;

namespace _5W2H.Application.Queries.DepartmentQueries.GetDepartmentById
{
    public class GetDepartmentByIdHandler : IRequestHandler<GetDepartmentByIdQuery, ResultViewModel<DepartmentViewModel>>
    {
        private readonly IDepartmentRepository _repository;

        public GetDepartmentByIdHandler(IDepartmentRepository repository)
        {
            _repository = repository;
        }


        public async Task<ResultViewModel<DepartmentViewModel>> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            var department = await _repository.GetByIdAsync(request.Id);

            var model = DepartmentViewModel.FromEntity(department);

            return ResultViewModel<DepartmentViewModel>.Success(model);
        }
    }
}