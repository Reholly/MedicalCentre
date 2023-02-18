using MedicalCentre.Models;
using MedicalCentre.Pages.DoctorWindowPages;
using MedicalCentre.Services;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;

namespace MedicalCentre.ViewModels
{
    public class DoctorViewModel
    {
        public ObservableCollection<Appointment> Appointments { get; set; } = new();
        public MedicalExamination SelectedAppointment { get; set; }
        public ICommand AddRowCommand { get; set; }
        public ICommand ShowInputHelpCommand { get; set; }
        public ICommand ShowTodaysAppointmentsCommand { get; set; }
        public ICommand ShowAllPatientsCommand { get; set; }

        public DoctorViewModel()
        {
            AddRowCommand = new RelayCommand(AddRow);
            ShowInputHelpCommand = new RelayCommand(ShowInputHelp);
            ShowTodaysAppointmentsCommand = new RelayCommand(ShowTodaysAppointments);
            ShowAllPatientsCommand = new RelayCommand(ShowAllPatients);
        }

        private void AddRow() => Appointments.Add(new());
        private void ShowInputHelp() => MessageBox.Show("DateTime input foramt: MM/DD/YYYY HH:MM:SS AM (or PM)");
        private void ShowTodaysAppointments()
        {
            NavigationWindow win = new();
            win.Content = new TodaysAppointments();
            win.Show();
        }

        private void ShowAllPatients()
        {
            NavigationWindow win = new();
            win.Content = new AllPatientsPage();
            win.Show();
        }
    }
}