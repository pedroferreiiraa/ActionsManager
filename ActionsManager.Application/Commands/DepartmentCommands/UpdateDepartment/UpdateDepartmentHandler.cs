using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _5W2H.Application.Models;
using _5W2H.Core.Entities;
using _5W2H.Core.Repositories;
using MediatR;

namespace _5W2H.Application.Commands.DepartmentCommands.UpdateDepartment
{
    public class UpdateDepartmentHandler : IRequestHandler<UpdateDepartmentCommand, ResultViewModel<Department>>
    {
        private readonly IDepartmentRepository _departmentRepository;

    public UpdateDepartmentHandler(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }
    
    public async Task<ResultViewModel<Department>> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
    {
        var department = await _departmentRepository.GetByIdAsync(request.Id);

        if (department == null)
        {
            return ResultViewModel<Department>.Error("Departamento não encontrado");
        }
        
        department.Update(request.LiderId, request.GestorId);
        await _departmentRepository.UpdateAsync(department);
        
        return ResultViewModel<Department>.Success(department);
    }
    }
}