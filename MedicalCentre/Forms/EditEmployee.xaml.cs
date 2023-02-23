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
using System.Windows.Shapes;
using MedicalCentre.Models;
using MedicalCentre.DatabaseLayer;

namespace MedicalCentre.Forms
{
    /// <summary>
    /// Логика взаимодействия для EditEmployee.xaml
    /// </summary>
    public partial class EditEmployee : Window
    {
        public EditEmployee()
        {
            InitializeComponent();
        }

        public async void Edit(object sendet, RoutedEventArgs e)
        {
            uint accountId = uint.Parse(AccountId.Text.ToString());
            string password = Password.Password;

            Database<Account> accDb = new Database<Account>();
            Database<Employee> empDb = new Database<Employee>();    
            Account currentAccount = await accDb.GetItemByIdAsync(accountId);
            Employee currentEmployee = empDb.GetItemById(currentAccount.EmployeeAccountId);

            currentAccount.Password = password;

            currentEmployee.Name = Name.Text;
            currentEmployee.Surname = Surname.Text;
            currentEmployee.Patronymic = Patronymic.Text;
            currentEmployee.Salary = double.Parse(Salary.Text);
            currentEmployee.RoleId = uint.Parse(RoleId.Text.ToString());
            currentEmployee.Specialization = Specialization.Text;   

            await empDb.UpdateItemAsync(currentEmployee);
            await accDb.UpdateItemAsync(currentAccount);
            Close();
        }
    }
}
