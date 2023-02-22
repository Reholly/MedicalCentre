using MedicalCentre.DatabaseLayer;
using MedicalCentre.Models;
using MedicalCentre.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace MedicalCentre.Windows
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
           
            InitializeComponent();                  
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string login = Login.Text;
            string password = Password.Password;

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

            Close();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}   
