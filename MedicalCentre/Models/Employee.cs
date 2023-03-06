using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MedicalCentre.Models
{
    public class Employee : INotifyPropertyChanged
    {
        public uint Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Patronymic { get; set; } = null!;
        public string Specialization { get; set; } = null!;
        public double Salary { get; set; }
        public uint RoleId { get; set; }
        public bool IsOnline { get; set; } = false;
        public Employee() { }

        public Employee(string name, string surname, string patronymic, string specialization, double salary, uint role)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            Specialization = specialization;
            Salary = salary;
            RoleId = role;
        }
        public Employee(uint id, string name, string surname, string patronymic, string specialization, double salary, uint role)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            Specialization = specialization;
            Salary = salary;
            RoleId = role;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
