using MedicalCentre.Pages.AdminWindowPages;
using MedicalCentre.Pages.OperatorPages;
using MedicalCentre.Windows;
using System.Windows.Input;

namespace MedicalCentre.ViewModels
{
    public class OperatorWindowViewModel
    {
        private readonly OperatorWindow window;
        public ICommand PatientsPageOpeningCommand { get; set; }
        public ICommand AppointmentsManagementPageOpeningCommand { get; set; }
        public ICommand WindowClosingCommand { get; set; }
        public OperatorWindowViewModel(OperatorWindow window)
        {
            this.window = window;
            PatientsPageOpeningCommand = new RelayCommand(OpenPatientsPage);
            AppointmentsManagementPageOpeningCommand = new RelayCommand(OpenAppointmentsManagementPage);
            WindowClosingCommand = new RelayCommand(Close);
        }

        private void OpenPatientsPage() => window.MainFrame.Content = new PatientsPage();
        private void OpenAppointmentsManagementPage() => window.MainFrame.Content = new AppointmentsManagementPage();
        private void Close() => window.Close();
    }
}