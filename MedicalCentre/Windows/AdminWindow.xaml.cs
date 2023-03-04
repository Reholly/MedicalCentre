using MedicalCentre.Pages.AdminWindowPages;
using MedicalCentre.Services;
using MedicalCentre.ViewModels;
using System.Windows;

namespace MedicalCentre.Windows
{
    public partial class AdminWindow : Window
    {
        public AdminWindow(uint employeeId)
        {
            InitializeComponent();

            EmployeeNameBinderService.BindName(employeeId, RoleName, EmployeeName);

            MainFrame.Content = new AnalyticsPage();
            DataContext = new AdminViewModel(this);
        }      
    }
}