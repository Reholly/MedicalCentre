using MedicalCentre.Authentification;
using MedicalCentre.Models;
using MedicalCentre.Pages.AdminWindowPages;
using MedicalCentre.Pages.GeneralPages;
using MedicalCentre.Windows;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MedicalCentre.ViewModels
{
    public class AdminViewModel
    {
        private AdminWindow adminWindow;
        private Account currentAccount;
        public ICommand? CloseCommand { get; set; }
        public ICommand? OpenEmployeesCommand { get; set; }
        public ICommand? OpenPatientsCommand { get; set; }
        public ICommand? OpenMainCommand { get; set; }
        public ICommand? OpenCentreSettings { get; set; }
        public AdminViewModel(AdminWindow window, Account account)
        {
            adminWindow = window;
            currentAccount = account;
            CloseCommand = new RelayCommandAsync(Close);
            OpenEmployeesCommand = new RelayCommand(OpenEmployeesPage);
            OpenPatientsCommand = new RelayCommand(OpenPatientsPage);
            OpenMainCommand = new RelayCommand(OpenMainPage);
            OpenCentreSettings = new RelayCommand(OpentSettingsPage);
        }   

        private async Task Close()
        {
            var auth = new AuthentificationService();
            await auth.LogOut(adminWindow, currentAccount);
        }

        private void OpenEmployeesPage()
        {
            adminWindow.MainFrame.Content = new EmployeesManagementPage();
        }

        private void OpenPatientsPage()
        {
            adminWindow.MainFrame.Content = new PatientsPage();
        }

        private void OpenMainPage()
        {
            adminWindow.MainFrame.Content = new MainPage();
        }

        private void OpentSettingsPage()
        {
            adminWindow.MainFrame.Content = new CentreSettingsPage();
        }
    }
}