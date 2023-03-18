using MedicalCentre.DatabaseLayer;
using MedicalCentre.Models;
using MedicalCentre.Pages.DoctorWindowPages;
using MedicalCentre.Services;
using System.Windows.Input;

namespace MedicalCentre.ViewModels.DoctorWindowPagesViewModels
{
    public class AppointmentPageViewModel
    {
        private readonly Appointment appointment;
        private readonly AppointmentPage page;
        public ICommand NotePrintingCommand { get; set; }
        public AppointmentPageViewModel(Appointment appointment, AppointmentPage page)
        {
            this.appointment = appointment;
            this.page = page;
            NotePrintingCommand = new RelayCommand(PrintNote);
            Initialize();
        }

        private void Initialize()
        {
            string patient = new ContextRepository<Patient>().GetItemById((uint) appointment.PatientId).ToStringForAppointment();
            page.PatientsSNP.Text = patient;
        }

        private void PrintNote() => OpenBrowserService.OpenPageInBrowser("https://www.youtube.com/watch?v=dQw4w9WgXcQ");
    }
}