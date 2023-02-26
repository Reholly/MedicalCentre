using MedicalCentre.DatabaseLayer;
using MedicalCentre.Models;
using MedicalCentre.Services;
using System;
using System.Threading.Tasks;
using System.Windows; 

namespace MedicalCentre.Forms
{
     public partial class RegisterEmployeeForm : Window
     {
        public RegisterEmployeeForm()
        {
            InitializeComponent();
            
        }

        private async void Register(object sender, RoutedEventArgs e)
        {
            try
            {
                AuthentificatorService auth = new AuthentificatorService(new AuthentificationService());

                Database<Employee> empDb = new Database<Employee>();
                Database<Account> accDb = new Database<Account>();

                Employee newEmployee = new Employee(uint.Parse(EmployeeId.Text),
                                            EmployeeName.Text,
                                            Surname.Text,
                                            Patronymic.Text,
                                            Specialization.Text,
                                            double.Parse(Salary.Text),
                                            uint.Parse(RoleId.Text));
                Account newAccount = new Account(uint.Parse(AccountId.Text),
                                                    newEmployee.Id, 
                                                    Password.Password);

                var result = await auth.Register(newAccount.Id, newAccount.Password, newEmployee);
                Close();
                                           
            }
            catch(Exception ex)
            {
                //MessageBox.Show("Что-то пошло не так. Неверные данные или сбой на стороне сервера, обратитесь к сис.админу и попробуйте позже.");
                await LoggerService.CreateLog(ex.Message, false);
                Close();
            }
        }
    }
}
