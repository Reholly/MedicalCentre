using MedicalCentre.Pages.AdminWindowPages;
using MedicalCentre.Pages.OperatorPages;
using MedicalCentre.Services;
using System.Windows;
using System.Windows.Input;

namespace MedicalCentre.Windows
{
    public partial class OperatorWindow : Window
    {
        public OperatorWindow(uint employeeId)
        {
            InitializeComponent();

            EmployeeNameBinderService.BindName(employeeId, RoleName, EmployeeName);

            MainFrame.Content = new AnalyticsPage();
        }

        private void Open_Patients(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new PatientsPage();
        }

        private void Open_AppointmentsManagement(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new AppointmentsManagement();
        }

        private void CloseIcon_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            Close();
        }
    }
}
