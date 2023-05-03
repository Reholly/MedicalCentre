using MedicalCentre.FormsViewModels;
using MedicalCentre.Models;
using System.Windows;


namespace MedicalCentre.Forms
{
    public partial class EmployeeProfileForm : Window
    {
        public EmployeeProfileForm(Employee employee)
        {
            InitializeComponent();

            DataContext = new EmployeeProfileViewModel(this, employee);
        }
    }
}
