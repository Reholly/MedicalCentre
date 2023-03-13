using MedicalCentre.DatabaseLayer;
using MedicalCentre.Models;
using MedicalCentre.Pages.DoctorWindowPages;
using MedicalCentre.ViewModels;
using MedicalCentre.Windows;
using System.Windows.Input;

namespace MedicalCentre.UserControls.ViewModels
{
    public class AppointmentCardViewModel
    {
        private readonly Appointment appointment;
        private DoctorWindow window;
        public ICommand AppointmentStartingCommand { get; set; }
        public AppointmentCardViewModel(AppointmentCard card, Appointment appointment)
        {
            this.appointment = appointment;
            ContextRepository<Patient> repository = new();
            card.Card.Text = repository.GetItemById((uint)appointment.PatientId).ToString();
            AppointmentStartingCommand = new RelayCommand(StartAppointment);
        }

        private void StartAppointment() => window.MainFrame.Content = new AppointmentPage();
    }
}