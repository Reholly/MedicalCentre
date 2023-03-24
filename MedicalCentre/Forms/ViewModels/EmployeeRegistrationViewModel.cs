using MedicalCentre.Authentification;
using MedicalCentre.DatabaseLayer;
using MedicalCentre.Models;
using MedicalCentre.Services;
using MedicalCentre.ViewModels;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MedicalCentre.Forms.ViewModels
{
    internal class EmployeeRegistrationViewModel
    {
        public ICommand? RegisterCommand { get; set; }
        public ICommand? CloseCommand { get; set; }

        private EmployeeRegistration profile;

        public EmployeeRegistrationViewModel(EmployeeRegistration profile)
        {
            this.profile = profile;
            RegisterCommand = new RelayCommandAsync(Register);
            CloseCommand = new RelayCommand(()=> profile.Close());
        }

        private async Task Register()
        {         
            var accDb = new ContextRepository<Account>();
            var empDb = new ContextRepository<Employee>();

            Random random = new Random();
            uint empId = uint.Parse(random.Next(1, int.MaxValue).ToString());
            uint accId = uint.Parse(random.Next(1, int.MaxValue).ToString());

            Employee employee = new Employee(empId, profile.Name.Text, accId, profile.Surname.Text,
                                            profile.Patronymic.Text, profile.Specialization.Text,
                                            profile.Description.Text, double.Parse(profile.Salary.Text));
            Account account = new Account(accId, empId, profile.Login.Text, profile.Password.Text, profile.Role.Text);

            try
            {
                AuthentificationService authentificationService = new();
                await authentificationService.RegisterUser(account);
                await empDb.AddItemAsync(employee);
                LoggerService.CreateLog($"Регистрация нового сотрудника {account.Id} - {account.Username}", true);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Неизвестная ошибка в создании аккаунта, попробуйте еще раз");
                LoggerService.CreateLog($"Ошибка в регистрации нового сотрудника {account.Id} - {account.Username}", false);
                profile.Close();
            }
           
            profile.Close();           
        }
    }
}
