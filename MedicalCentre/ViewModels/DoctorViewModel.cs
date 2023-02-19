using MedicalCentre.Models;
using MedicalCentre.Pages.DoctorWindowPages;
using MedicalCentre.Services;
using MedicalCentre.Windows;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;

namespace MedicalCentre.ViewModels
{
    public class DoctorViewModel
    {
        private readonly DoctorWindow window;
        public ObservableCollection<Appointment> Appointments { get; set; } = new();
        public MedicalExamination SelectedAppointment { get; set; }
        public ICommand AddRowCommand { get; set; }
        public ICommand ShowInputHelpCommand { get; set; }
        public ICommand ShowTodaysAppointmentsCommand { get; set; }
        public ICommand ShowAllPatientsCommand { get; set; }

        public DoctorViewModel(DoctorWindow window)
        {
            this.window = window;
            AddRowCommand = new RelayCommand(AddRow);
            ShowInputHelpCommand = new RelayCommand(ShowInputHelp);
            ShowTodaysAppointmentsCommand = new RelayCommand(ShowTodaysAppointments);
            ShowAllPatientsCommand = new RelayCommand(ShowAllPatients);
        }

        private void AddRow() => Appointments.Add(new());
        private void ShowInputHelp() => MessageBox.Show("DateTime input foramt: MM/DD/YYYY HH:MM:SS AM (or PM)");

        private void CheckFrames()
        {
            if (window.DoctorLeftFrame.Content != null)
                window.DoctorRightFrame.Content = window.DoctorLeftFrame.Content;
        }

        private void ShowTodaysAppointments()
        {
            CheckFrames();
            window.DoctorLeftFrame.Content = new TodaysAppointments();
        }

        private void ShowAllPatients()
        {
            CheckFrames();
            window.DoctorLeftFrame.Content = new AllPatientsPage();
        }
    }
}