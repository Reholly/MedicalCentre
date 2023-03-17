﻿using MedicalCentre.Authentification;
using MedicalCentre.Models;
using MedicalCentre.Pages.AdminWindowPages;
using MedicalCentre.Pages.OperatorPages;
using MedicalCentre.Windows;
using System.Threading.Tasks;
using System.Windows.Automation.Peers;
using System.Windows.Input;

namespace MedicalCentre.ViewModels
{
    public class OperatorWindowViewModel
    {
        private readonly OperatorWindow window;
        private readonly Account currentAccount;
        public ICommand PatientsPageOpeningCommand { get; set; }
        public ICommand AppointmentsManagementPageOpeningCommand { get; set; }
        public ICommand CloseCommand { get; set; }
        public OperatorWindowViewModel(OperatorWindow window, Account account)
        {
            this.window = window;
            this.currentAccount = account;
            PatientsPageOpeningCommand = new RelayCommand(OpenPatientsPage);
            AppointmentsManagementPageOpeningCommand = new RelayCommand(OpenAppointmentsManagementPage);
            CloseCommand = new RelayCommandAsync(Close);
        }

        private void OpenPatientsPage() => window.MainFrame.Content = new PatientsPage();
        private void OpenAppointmentsManagementPage() => window.MainFrame.Content = new MedicalCentre.Pages.OperatorPages.MainPage();
        private async Task Close()
        {
            var auth = new AuthentificationService();
            auth.LogOut(window, currentAccount);
            window.Close();
        }
    }
}