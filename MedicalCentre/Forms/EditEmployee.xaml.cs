using MedicalCentre.DatabaseLayer;
using MedicalCentre.Models;
using MedicalCentre.Services;
using System;
using System.Threading.Tasks;
using System.Windows;

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

        public async Task Edit(object sendet, RoutedEventArgs e)
        {
            try
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

                LoggerService.CreateLog($"Account {accountId} with Employee {currentEmployee.Id} was edit.", true);
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Что-то пошло не так. Ошибка в данных или сбой на стороне сервера, попробуйте позже и обратитесь к сис.админу.");
                LoggerService.CreateLog($"{ex.Message}", false);
            }
            Close();
        }
    }
}