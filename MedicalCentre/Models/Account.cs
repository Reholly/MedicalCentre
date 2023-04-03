using MedicalCentre.Authentification;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MedicalCentre.Models
{
    public class Account : INotifyPropertyChanged
    {
        public uint Id { get; set; }
        public uint EmployeeAccountId { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public Roles Role { get; set; } = default!;
        public bool IsOnline { get; set; } = false;

        public Account() { }

        public Account(uint employeeAccount, string username, string password, Roles role)
        {
            EmployeeAccountId = employeeAccount;
            Username = username;
            Password = password;
            Role = role;
        }

        public Account(uint id, uint employeeAccount, string username, string password, Roles role)
        {
            Id = id;
            EmployeeAccountId = employeeAccount;
            Username = username;
            Password = password;
            Role = role;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}