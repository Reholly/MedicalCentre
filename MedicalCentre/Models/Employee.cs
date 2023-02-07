using MedicalCentre.Roles;

namespace MedicalCentre.Models
{
    public class Employee
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string? Patronymic { get; private set; }
        public IRole Role { get; private set; }
        public Specialization Specialization { get; private set; }
    }
}
