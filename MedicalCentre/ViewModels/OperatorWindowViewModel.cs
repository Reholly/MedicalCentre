using MedicalCentre.Pages.AdminWindowPages;
using MedicalCentre.Pages.OperatorPages;
using MedicalCentre.Windows;
using System.Windows.Input;

namespace MedicalCentre.ViewModels
{
    public class OperatorWindowViewModel
    {
        private readonly OperatorWindow window;
        public ICommand OpenPatientsPageCommand { get; set; }
        public ICommand OpenAppointmentsManagementPageCommand { get; set; }
        public ICommand CloseWindowCommand { get; set; }
        public OperatorWindowViewModel(OperatorWindow window)
        {
            this.window = window;
            window.MainFrame.Content = new AnalyticsPage();
            OpenPatientsPageCommand = new RelayCommand(OpenPatientsPage);
            OpenAppointmentsManagementPageCommand = new RelayCommand(OpenAppointmentsManagement);
            CloseWindowCommand = new RelayCommand(CloseWindow);
        }

        private void OpenPatientsPage() => window.MainFrame.Content = new PatientsPage();
        private void OpenAppointmentsManagement() => window.MainFrame.Content = new AppointmentsManagementPage();
        private void CloseWindow() => window.Close();
    }
}