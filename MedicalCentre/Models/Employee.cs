using MedicalCentre.Roles;

namespace MedicalCentre.Models
{
    public class Employee
    {
        public uint Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Patronymic { get; set; } = null!;
        public Role Role { get; set; } = null!;
        public Specialization Specialization { get; set; } = null!;
    }
}
