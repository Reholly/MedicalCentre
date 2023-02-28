using MedicalCentre.DatabaseLayer;
using MedicalCentre.Models;
using MedicalCentre.Pages.AdminWindowPages;
using MedicalCentre.Pages.GeneralPages;
using MedicalCentre.Services;
using System.Windows;
using System.Windows.Input;

namespace MedicalCentre.Windows
{
    public partial class AdminWindow : Window
    {
        public AdminWindow(uint employeeId)
        {
            InitializeComponent();

            EmployeeNameBinderService.BindName(employeeId, RoleName, EmployeeName);

            MainFrame.Content = new Analytics();
        }

        private void CloseIcon_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        public void OpenEmployeesPage(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new EmployeesManagement();
        }

        private void OpenPatientsPage(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new Patients();
        }

        private void OpenAnalyticsPage(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new Analytics();
        }

        private void OpenStoragePage(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new StoragePage();
        }

        private void OpentSettingsPage(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new CentreSettings();
        }
    }
}