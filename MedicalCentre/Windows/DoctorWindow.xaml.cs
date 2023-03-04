using System.Windows;
using System.Windows.Input;
using MedicalCentre.Models;
using MedicalCentre.Services;
using MedicalCentre.ViewModels;

namespace MedicalCentre.Windows
{
    public partial class DoctorWindow : Window
    {
        public DoctorWindow(uint employeeId)
        {
            InitializeComponent();


            EmployeeNameBinderService.BindName(employeeId, RoleName, EmployeeName);
            DataContext = new DoctorViewModel(this);
        }

        private void CloseIcon_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

    }
}