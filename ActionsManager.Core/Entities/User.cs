using System.Collections.Generic;
using _5W2H.Core.Enums;

namespace _5W2H.Core.Entities
{
    public class User : BaseEntity
    {
        
        public User() { }
        
        public User(string fullName, string email, string password, string role, int? departmentId)
        {
            FullName = fullName;
            Email = email;
            Password = password;
            Role = role;
            DepartmentId = departmentId; // Agora é uma referência a um objeto Department

            Projects = new List<Project>();
            Actions = new List<Acao>();
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Role { get; private set; }
        
        public ICollection<Project> Projects { get; set; } 
        
        public List<Acao> Actions { get; set; }
        
        // Referência ao departamento
        public Department Department { get; set; } 
        public int? DepartmentId { get; set; }
        

        public void Update(string fullName, string email, string role, int departmentId)
        {
            FullName = fullName;
            Email = email;
            Role = role;
            DepartmentId = departmentId; // Atualiza para um novo objeto Department
        }
    }
}