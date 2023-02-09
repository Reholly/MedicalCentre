namespace MedicalCentre.Models
{
    public class Specialization
    {
        public uint Id { get; set; }
        public string Title { get; set; } = null!;
        public uint Salary { get; set; }

        public Specialization(uint id, string title, uint salary)
        {
            Id = id;
            Title = title;
            Salary = salary;
        }
    }
}
