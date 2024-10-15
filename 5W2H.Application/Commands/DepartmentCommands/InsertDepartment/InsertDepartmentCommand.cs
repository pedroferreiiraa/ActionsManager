using _5W2H.Application.Models;
using _5W2H.Core.Entities;
using MediatR;

namespace _5W2H.Application.Commands.DepartmentCommands.InsertDepartment;

public class InsertDepartmentCommand : IRequest<ResultViewModel<int>>
{
    public string Name { get; set; }
    
    public Department ToEntity()
        => new (Name);
}