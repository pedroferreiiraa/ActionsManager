using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _5W2H.Application.Models;
using _5W2H.Core.Entities;
using MediatR;

namespace _5W2H.Application.Commands.DepartmentCommands.UpdateDepartment
{
    public class UpdateDepartmentCommand : IRequest<ResultViewModel<Department>>
{
    public int Id { get; set; }
    public int LiderId { get; set; }
    public int GestorId { get; set; }
}
}