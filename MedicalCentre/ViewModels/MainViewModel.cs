using MedicalCentre.DatabaseLayer;
using MedicalCentre.Models;
using MedicalCentre.Services;
using MedicalCentre.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void Login()
        {
            string login = window.Login.Text;
            string password = window.Password.Password;

            AuthentificatorService authentificator = new AuthentificatorService(new AuthentificationService());

            Account currentAccount = authentificator.Login(uint.Parse(login), password).Result;

            Database<Employee> employeeDb = new Database<Employee>();

            if (currentAccount != null)
            {
                currentAccount.EmployeeAccount = employeeDb.GetItemById(currentAccount.Id).Result;
            }
            else
            {
                MessageBox.Show("Какие-то данные неверные, попробуйте снова");
                return;
            }

            Database<Role> roleDb = new Database<Role>();
            Role role = roleDb.GetItemById(currentAccount.EmployeeAccount.RoleId).Result;

            authentificator.CheckRole(role, currentAccount);

            window.Close();
        }

        private void Close() => window.Close();
    }
}
