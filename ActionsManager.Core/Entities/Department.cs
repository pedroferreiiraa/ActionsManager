using _5W2H.Core.Enums;

namespace _5W2H.Core.Entities
{
    public class Department : BaseEntity
    {
        public Department(string name, int liderId, int gestorId)
        {
            Name = name;
            LiderId = liderId;
            GestorId = gestorId;
            Users = new List<User>();
        }
        
        public string Name { get; private set; } // Nome do departamento (Enum)
        public int LiderId { get; private set; }
        public User Lider { get;  set; }
        public int GestorId { get; private set; }
        public User Gestor { get; set; }

        public ICollection<User> Users = new List<User>();

        public void Update( int liderId, int gestorId)
        {
            
            LiderId = liderId;
            GestorId = gestorId;
        }
    }
}