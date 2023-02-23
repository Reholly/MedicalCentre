using MedicalCentre.DatabaseLayer;
using MedicalCentre.Models;
using MedicalCentre.Services;
using MedicalCentre.Windows;
using System.Windows.Input;
using System.Windows;

namespace MedicalCentre.ViewModels
{
    public class MainViewModel
    {
        private MainWindow window;
        public ICommand LoginCommand { get; set; }
        public ICommand CloseCommand { get; set; }
        public MainViewModel(MainWindow window)
        {
            this.window = window;
            LoginCommand = new RelayCommand(Login);
            CloseCommand = new RelayCommand(Close);
        }

        private async void Login()
        {
            string login = window.Login.Text;
            string password = window.Password.Password;

            AuthentificatorService authentificator = new AuthentificatorService(new AuthentificationService());
            Account currentAccount = await authentificator.Login(uint.Parse(login), password);
            
            Database<Employee> employeeDb = new Database<Employee>();

            if (currentAccount != null)
            {
                Employee id = await employeeDb.GetItemByIdAsync(currentAccount.Id);
                currentAccount.EmployeeAccountId = id.Id;
            }
            else
            {
                MessageBox.Show("Какие-то данные неверны, попробуйте снова");
                return;
            }

            Database<Role> roleDb = new Database<Role>();
            Employee currentEmployee = await employeeDb.GetItemByIdAsync(currentAccount.EmployeeAccountId);
            Role role = await roleDb.GetItemByIdAsync(currentEmployee.RoleId); 

            await authentificator.CheckRole(role, currentAccount);

            window.Close();
        }

        private void Close() => window.Close();
    }
}
