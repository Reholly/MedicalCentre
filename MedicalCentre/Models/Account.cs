using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MedicalCentre.Models
{
    public class Account : INotifyPropertyChanged
    {
        public uint Id { get; set; }
        public Employee EmployeeAccount { get; set; } = null!;
        public string Password { get; set; } = null!;

        public Account() { }

        public Account(Employee employeeAccount, string password)
        {
            EmployeeAccount = employeeAccount;
            Password = password;
        }

        public Account(uint id, Employee employeeAccount, string password)
        {
            Id = id;
            EmployeeAccount = employeeAccount;
            Password = password;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
