using System;
using MedicalCentre.Models;
using System.Windows;
using MedicalCentre.ViewModels.FormsViewModels;


namespace MedicalCentre.Forms
{
    public partial class EmployeeProfileForm : Window
    {
        public EmployeeProfileForm(Employee employee, IServiceProvider provider)
        {
            InitializeComponent();

            DataContext = new EmployeeProfileViewModel(this, employee, provider);
        }
    }
}
