using MedicalCentre.Authentification;
using MedicalCentre.Models;
using MedicalCentre.Pages.DoctorWindowPages;
using MedicalCentre.Windows;
using System.Windows;
using System.Windows.Input;

namespace MedicalCentre.ViewModels
{
    public class DoctorViewModel
    {
        private readonly DoctorWindow window;
        private readonly Account account;
        public ICommand ShowInputHelpCommand { get; set; }
        public ICommand ShowTodaysAppointmentsCommand { get; set; }
        public ICommand ShowAllPatientsCommand { get; set; }
        public ICommand WindowClosingCommand { get; set; }

        public DoctorViewModel(DoctorWindow window, Account account)
        {
            this.window = window;
            this.account = account;
            ShowInputHelpCommand = new RelayCommand(ShowInputHelp);
            ShowTodaysAppointmentsCommand = new RelayCommand(ShowTodaysAppointments);
            ShowAllPatientsCommand = new RelayCommand(ShowAllPatients);
            WindowClosingCommand = new RelayCommand(Close);
        }

        private void ShowInputHelp() => MessageBox.Show("DateTime input foramt: MM/DD/YYYY HH:MM:SS AM (or PM)");

        private void ShowTodaysAppointments() => window.MainFrame.Content = new TodaysAppointments();
        //показать список приёмов на сегодня

        private void ShowAllPatients() => window.MainFrame.Content = new AllPatientsPage();
        //показать список всех пациентов

        private void Close() //метод для LogOut кнопки
        {
            new AuthentificationService().LogOut(window, account);
            window.Close();
        }
    }
}