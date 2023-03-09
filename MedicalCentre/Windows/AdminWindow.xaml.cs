using MedicalCentre.Models;
using MedicalCentre.ViewModels;
using System.Windows;
using MedicalCentre.Pages.AdminWindowPages;
using System.Threading;
using MedicalCentre.Services;

namespace MedicalCentre.Windows
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

            MainFrame.Content = new AnalyticsPage();
            DataContext = new AdminViewModel(this, account);
        }      
    }
}