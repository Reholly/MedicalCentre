using MedicalCentre.DatabaseLayer;
using MedicalCentre.Models;
using MedicalCentre.ViewModels;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MedicalCentre.Forms.ViewModels
{
    internal class EmployeeProfileViewModel
    {
        public ICommand? CloseCommand { get; set; }
        public ICommand? SaveCommand { get; set; }
        public ICommand? DeleteCommand { get; set; }

        private EmployeeProfile profile;
        private Employee employee;

        public EmployeeProfileViewModel(EmployeeProfile profile, Employee employee)
        {
            this.profile = profile;
            this.employee = employee;

            var accDb = new ContextRepository<Account>();

            CloseCommand = new RelayCommand(Close);
            DeleteCommand = new RelayCommandAsync(Delete);
            SaveCommand = new RelayCommandAsync(Save);

            if (accDb.GetItemById(employee.AccountId).IsOnline) this.profile.IsOnline.IsChecked = true;
            else this.profile.IsOnline.IsChecked = false;

            this.profile.Password.Text = accDb.GetItemById(employee.AccountId).Password;
            this.profile.Login.Text = accDb.GetItemById(employee.AccountId).Username;
            this.profile.Name.Text = employee.Name;
            this.profile.Surname.Text = employee.Surname;
            this.profile.Patronymic.Text = employee.Patronymic;
            this.profile.Salary.Text = employee.Salary.ToString();
            this.profile.Description.Text = employee.Description.ToString();
        }

        private async Task Delete()
        {
            var empDb = new ContextRepository<Employee>();
            var accDb = new ContextRepository<Account>();

            Account account = await accDb.GetItemByIdAsync(employee.AccountId);

            accDb.DeleteItemAsync(account);
            empDb.DeleteItemAsync(employee);

            Close();            
        }

        private async Task Save()
        {
            var accDb = new ContextRepository<Account>();
            Account account = await accDb.GetItemByIdAsync(employee.AccountId);
            account.Password = profile.Password.Text;
            account.Username = profile.Login.Text;

            account.IsOnline = profile.IsOnline.IsChecked.Value;

            employee.Name = profile.Name.Text;
            employee.Surname = profile.Surname.Text;
            employee.Patronymic = profile.Patronymic.Text;
            try
            {
                employee.Salary = double.Parse(profile.Salary.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Зарплата должна быть числом. Попробуйте позже.");
            }
            employee.Description = profile.Description.Text;


            var empDb = new ContextRepository<Employee>();

            accDb.UpdateItemAsync(account);
            empDb.UpdateItemAsync(employee);

            Close();
        }

        private void Close()
        {
            profile.Close();
        }
    }
}