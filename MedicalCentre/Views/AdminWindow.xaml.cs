using MedicalCentre.Models;
using MedicalCentre.Pages.AdminWindowPages;
using MedicalCentre.Services;
using MedicalCentre.ViewModels;
using System.Threading;
using System.Windows;

namespace MedicalCentre.Views
{
    public partial class AdminWindow : Window
    {
        public AdminWindow(Account account)
        {
            InitializeComponent();

            if (Thread.CurrentPrincipal == null || !Thread.CurrentPrincipal.IsInRole("Admin"))
            {
                Close();
            }

            EmployeeNameBinderService.BindName(account, RoleName, EmployeeName);

            MainFrame.Content = new MainPage();
            DataContext = new AdminViewModel(this, account);
        }
    }
}