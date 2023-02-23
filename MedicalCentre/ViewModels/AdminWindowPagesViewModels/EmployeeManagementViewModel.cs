using MedicalCentre.DatabaseLayer;
using MedicalCentre.Models;
using MedicalCentre.Pages.AdminWindowPages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;
using MedicalCentre.Forms;

namespace MedicalCentre.ViewModels.AdminWindowPagesViewModels
{
    internal class EmployeeManagementViewModel
    {
        public ObservableCollection<Employee> Employees { get; set; } = new();
        public ObservableCollection<Account> Accounts { get; set; } = new();    
        public Employee SelectedEmployee { get; set; }
        public ICommand ShowTableCommand { get; set; }
        public ICommand RegisterCommand{ get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        private EmployeesManagement page;
        public EmployeeManagementViewModel(EmployeesManagement page)
        {
            this.page = page;
            ShowTableCommand = new RelayCommand(ShowTable);
            RegisterCommand = new RelayCommand(RegisterEmployee);
        }
        private void ShowTable()
        {
            Database<Employee> empDb = new Database<Employee>();
            
            var employees = empDb.GetTable().Result;
            Employees = new ObservableCollection<Employee>(employees);

            page.EmployeesGrid.ItemsSource = Employees; 
            page.EmployeesGrid.Visibility = Visibility.Visible;

            Database<Account> accDb = new Database<Account>();

            var accounts = accDb.GetTable().Result;
            Accounts = new ObservableCollection<Account>(accounts);

            page.AccountsGrid.ItemsSource = Accounts;
            page.AccountsGrid.Visibility = Visibility.Visible;
        }
        private void RegisterEmployee()
        {
            MessageBox.Show("регистр");
            RegisterEmployeeForm window = new RegisterEmployeeForm();
            window.Show();
        }
    }
}
