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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows;

namespace MedicalCentre.ViewModels.AdminWindowPagesViewModels
{
    internal class EmployeeManagementViewModel
    {
        public ObservableCollection<Employee> Employees { get; set; } = new();
        public Employee SelectedEmployee { get; set; }
        public ICommand ShowTableCommand { get; set; }
        private EmployeesManagement page;
        public EmployeeManagementViewModel(EmployeesManagement page)
        {
            this.page = page;
            ShowTableCommand = new RelayCommand(ShowTable);
        }
        private void ShowTable()
        {
            Database<Employee> empDb = new Database<Employee>();
            
            var employees = empDb.GetTable().Result;
            Employees = new ObservableCollection<Employee>(employees);
            page.DataGridTest.ItemsSource = Employees; 
            page.DataGridTest.Visibility = Visibility.Visible;
        }
    }
}
