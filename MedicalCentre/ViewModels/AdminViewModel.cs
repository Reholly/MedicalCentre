using MedicalCentre.Authentification;
using MedicalCentre.Models;
using MedicalCentre.Pages.AdminWindowPages;
using MedicalCentre.Pages.GeneralPages;
using MedicalCentre.Windows;
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
        public ICommand? OpenAnalyticsCommand { get; set; }
        public ICommand? OpenStorageCommand { get; set; }
        public ICommand? OpenSettingsCommand { get; set; }
        public AdminViewModel(AdminWindow window, Account account)
        {
            adminWindow = window;
            currentAccount = account;
            CloseCommand = new RelayCommand(Close);
            OpenEmployeesCommand = new RelayCommand(OpenEmployeesPage);
            OpenPatientsCommand = new RelayCommand(OpenPatientsPage);
            OpenAnalyticsCommand = new RelayCommand(OpenAnalyticsPage);
            OpenStorageCommand = new RelayCommand(OpenStoragePage);
            OpenSettingsCommand = new RelayCommand(OpentSettingsPage);
        }   

        private void Close()
        {
            var auth = new AuthentificationService();
            auth.LogOut(adminWindow, currentAccount);
            adminWindow.Close();
        }

        private void OpenEmployeesPage()
        {
            adminWindow.MainFrame.Content = new EmployeesManagementPage();
        }

        private void OpenPatientsPage()
        {
            adminWindow.MainFrame.Content = new PatientsPage();
        }

        private void OpenAnalyticsPage()
        {
            adminWindow.MainFrame.Content = new AnalyticsPage();
        }

        private void OpenStoragePage()
        {
            adminWindow.MainFrame.Content = new StoragePage();
        }

        private void OpentSettingsPage()
        {
            adminWindow.MainFrame.Content = new CentreSettingsPage();
        }
    }
}