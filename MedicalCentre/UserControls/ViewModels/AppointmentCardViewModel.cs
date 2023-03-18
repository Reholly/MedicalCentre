using MedicalCentre.Models;
using MedicalCentre.Pages.DoctorWindowPages;
using MedicalCentre.ViewModels;
using System.Windows;
using System.Windows.Input;

namespace MedicalCentre.UserControls.ViewModels
{
    public class AppointmentCardViewModel
    {
        private readonly Appointment appointment;
        private readonly MainPage page;
        private readonly string patient;
        private readonly string doctor;
        public ICommand AppointmentStartingCommand { get; set; }
        public AppointmentCardViewModel(AppointmentCard card, Appointment appointment, MainPage page, string patient, string doctor)
        {
            this.page = page;
            this.appointment = appointment;
            this.patient = patient;
            this.doctor = doctor;
            card.Card.Text = doctor + ": " + patient;
            AppointmentStartingCommand = new RelayCommand(StartAppointment);
        }

        private void StartAppointment()
        {
            if (patient != "Тут_должен_быть_пациент" && doctor != "Тут_должен_быть_врач")
                page.WorkspaceFrame.Content = new AppointmentPage(appointment);
            else
                MessageBox.Show("Чёт приём кривой, как его начать-то?");
        }
    }
}