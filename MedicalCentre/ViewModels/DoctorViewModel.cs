using MedicalCentre.Pages.DoctorWindowPages;
using MedicalCentre.Windows;
using System.Windows;
using System.Windows.Input;
using MedicalCentre.Models;
using MedicalCentre.Authentification;
using System.Threading.Tasks;

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
            WindowClosingCommand = new RelayCommandAsync(Close);
        }

        private void ShowInputHelp() => MessageBox.Show("DateTime input foramt: MM/DD/YYYY HH:MM:SS AM (or PM)");

        private void ShowTodaysAppointments() //показать список приёмов на сегодня
        {
            window.MainFrame.Content = new TodaysAppointments();
        }

        private void ShowAllPatients() //показать список всех пациентов
        {
            window.MainFrame.Content = new AllPatientsPage();
        }

        private async Task Close() //метод для LogOut кнопки
        {
            await new AuthentificationService().LogOut(window, account);
            window.Close();
        }
    }
}