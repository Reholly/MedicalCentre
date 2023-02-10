using MedicalCentre.Roles;

namespace MedicalCentre.Models
{
    public class Employee
    {
        public uint Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Patronymic { get; set; } = null!;
        public string Specialization { get; set; } = null!;
        public double Salary { get; set; }
        public Role Role { get; set; } = null!;
    }
}
