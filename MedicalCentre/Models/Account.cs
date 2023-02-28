using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MedicalCentre.Models
{
    public class Account : INotifyPropertyChanged
    {
        public uint Id { get; set; }
        public uint EmployeeAccountId { get; set; } 
        public string Password { get; set; } = null!;

        public Account() { }

        public Account(uint employeeAccount, string password)
        {
            EmployeeAccountId = employeeAccount;
            Password = password;
        }

        public Account(uint id, uint employeeAccount, string password)
        {
            Id = id;
            EmployeeAccountId = employeeAccount;
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
