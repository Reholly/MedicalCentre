using System.Threading;
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

            if (Thread.CurrentPrincipal == null || !Thread.CurrentPrincipal.IsInRole("Doctor"))
            {
                Close();
            }

            EmployeeNameBinderService.BindName(account, RoleName, EmployeeName);
            DataContext = new DoctorViewModel(this, account);
        }
    }
}