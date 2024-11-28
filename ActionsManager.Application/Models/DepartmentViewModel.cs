using _5W2H.Core.Entities;

namespace _5W2H.Application.Models;

public class DepartmentViewModel
{
    
    public int Id { get; set; }
    public string Name { get; set; }
    public int LiderId { get; set;}
    public int GestorId { get; set; }
    public List<UserViewModel> Users { get; set; } = new();

    public static DepartmentViewModel FromEntity(Department entity) 
        {
            return new DepartmentViewModel 
    {
            Id = entity.Id,
            Name = entity.Name,
            LiderId = entity.LiderId,
            GestorId = entity.GestorId,
            Users = entity.Users?.Select(u => new UserViewModel(u)).ToList() ?? new List<UserViewModel>()
        };
        }
}