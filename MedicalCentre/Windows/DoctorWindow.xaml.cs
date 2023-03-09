using System.Windows;
using MedicalCentre.Models;
using MedicalCentre.Services;
using MedicalCentre.ViewModels;

namespace MedicalCentre.Windows
{
    public partial class DoctorWindow : Window
    {
        public DoctorWindow(Account account)
        {
            InitializeComponent();

            EmployeeNameBinderService.BindName(account, RoleName, EmployeeName);
            DataContext = new DoctorViewModel(this);
        }
    }
}