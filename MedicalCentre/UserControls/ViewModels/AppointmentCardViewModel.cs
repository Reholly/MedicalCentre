using MedicalCentre.DatabaseLayer;
using MedicalCentre.Models;
using MedicalCentre.Pages.DoctorWindowPages;
using MedicalCentre.ViewModels;
using MedicalCentre.Windows;
using System.Text;
using System.Windows.Input;

namespace MedicalCentre.UserControls.ViewModels
{
    public class AppointmentCardViewModel
    {
        private readonly Appointment appointment;
        private readonly MainPage page;
        public AppointmentCardViewModel(AppointmentCard card, Appointment appointment, MainPage page, string patient, string doctor)
        {
            this.page = page;
            this.appointment = appointment;
            card.Card.Text = doctor + ": " + patient;
        }
    }
}