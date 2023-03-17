using MedicalCentre.Models;
using MedicalCentre.Pages.DoctorWindowPages;
using MedicalCentre.Services;
using MedicalCentre.ViewModels;
using System.Threading;
using System.Windows;

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

            MainFrame.Content = new MainPage();
            EmployeeNameBinderService.BindName(account, RoleName, EmployeeName);
            DataContext = new DoctorViewModel(this, account);
        }
    }
}