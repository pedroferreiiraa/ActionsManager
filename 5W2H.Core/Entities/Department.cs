using _5W2H.Core.Enums;

namespace _5W2H.Core.Entities
{
    public class Department : BaseEntity
    {
        public Department(string name)
        {
            Name = name;
            Users = [];
        }
        
        public string Name { get; private set; } // Nome do departamento (Enum)
        public List<User> Users { get; private set; } // Inicialização aqui
    }
}