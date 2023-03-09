using MedicalCentre.Pages.DoctorWindowPages;
using MedicalCentre.Windows;
using System.Windows;
using System.Windows.Input;

namespace MedicalCentre.ViewModels
{
    public class DoctorViewModel
    {
        private readonly DoctorWindow window;
        public ICommand ShowInputHelpCommand { get; set; }
        public ICommand ShowTodaysAppointmentsCommand { get; set; }
        public ICommand ShowAllPatientsCommand { get; set; }

        public DoctorViewModel(DoctorWindow window)
        {
            this.window = window;
            ShowInputHelpCommand = new RelayCommand(ShowInputHelp);
            ShowTodaysAppointmentsCommand = new RelayCommand(ShowTodaysAppointments);
            ShowAllPatientsCommand = new RelayCommand(ShowAllPatients);
        }

        private void ShowInputHelp() => MessageBox.Show("DateTime input foramt: MM/DD/YYYY HH:MM:SS AM (or PM)");

        private void ShowTodaysAppointments()
        {
            window.MainFrame.Content = new TodaysAppointments();
        }

        private void ShowAllPatients()
        {
            window.MainFrame.Content = new AllPatientsPage();
        }
    }
}