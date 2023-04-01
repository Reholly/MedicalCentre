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

            EmployeeNameBinderService.BindName(account, RoleName, EmployeeName);
            MainFrame.Content = new DoctorMainPage(this, account);
            DataContext = new DoctorViewModel(this, account);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}