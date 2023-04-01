using MedicalCentre.Authentification;
using MedicalCentre.Models;
using MedicalCentre.Pages.AdminWindowPages;
using MedicalCentre.Windows;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MedicalCentre.ViewModels
{
    public class AdminViewModel
    {
        private readonly AdminWindow _adminWindow;
        private readonly Account _currentAccount;
        public ICommand? CloseCommand { get; set; }
        public ICommand? OpenEmployeesCommand { get; set; }
        public ICommand? OpenPatientsCommand { get; set; }
        public ICommand? OpenMainCommand { get; set; }
        public ICommand? OpenCentreSettings { get; set; }
        public AdminViewModel(AdminWindow window, Account account)
        {
            _adminWindow = window;
            _currentAccount = account;
            CloseCommand = new RelayCommandAsync(Close);
            OpenEmployeesCommand = new RelayCommand(OpenEmployeesPage);
            OpenPatientsCommand = new RelayCommand(OpenPatientsPage);
            OpenMainCommand = new RelayCommand(OpenMainPage);
            OpenCentreSettings = new RelayCommand(OpentSettingsPage);
        }

        private async Task Close()
        {
            var auth = new AuthentificationService();
            await auth.LogOut(_adminWindow, _currentAccount);
        }

        private void OpenEmployeesPage()
        {
            _adminWindow.MainFrame.Content = new EmployeesManagementPage();
        }

        private void OpenPatientsPage()
        {
            _adminWindow.MainFrame.Content = new PatientsPage();
        }

        private void OpenMainPage()
        {
            _adminWindow.MainFrame.Content = new MainPage();
        }

        private void OpentSettingsPage()
        {
            _adminWindow.MainFrame.Content = new CentreSettingsPage();
        }
    }
}