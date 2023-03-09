using MedicalCentre.Pages.SystemAdminPages;
using MedicalCentre.Services;
using System.Windows;
using System.Windows.Input;

namespace MedicalCentre.Windows
{
    public partial class SystemAdminWindow : Window
    {
        public SystemAdminWindow(uint employeeId)
        {
            InitializeComponent();

           // EmployeeNameBinderService.BindName(employeeId, RoleName, EmployeeName);
        }
        private void CloseIcon_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void Open_LogsPanel(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new LogsPanel();
        }

        private void Open_DatabaseSettings(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new DatabaseSettings();
        }
    }
}