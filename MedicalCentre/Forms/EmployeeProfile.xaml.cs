using MedicalCentre.Forms.ViewModels;
using MedicalCentre.Models;
using System.Windows;


namespace MedicalCentre.Forms
{
 public partial class EmployeeProfile : Window
    {
        public EmployeeProfile(Employee employee)
        {
            InitializeComponent();

            DataContext = new EmployeeProfileViewModel(this, employee);
        }
    }
}
