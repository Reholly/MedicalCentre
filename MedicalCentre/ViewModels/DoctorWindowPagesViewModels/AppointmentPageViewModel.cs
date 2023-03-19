using MedicalCentre.DatabaseLayer;
using MedicalCentre.Models;
using MedicalCentre.Pages.DoctorWindowPages;
using MedicalCentre.Services;
using System.Threading.Tasks;
using System.Windows.Input;
using System;

namespace MedicalCentre.ViewModels.DoctorWindowPagesViewModels
{
    public class AppointmentPageViewModel
    {
        private readonly Appointment appointment;
        private readonly AppointmentPage page;
        private readonly DoctorMainPage mainPage;
        public ICommand NotePrintingCommand { get; set; }
        public ICommand AppointmentEndingCommand { get; set; }
        public AppointmentPageViewModel(Appointment appointment, AppointmentPage page, DoctorMainPage mainPage)
        {
            this.appointment = appointment;
            this.page = page;
            this.mainPage = mainPage;
            NotePrintingCommand = new RelayCommand(PrintNote);
            AppointmentEndingCommand = new RelayCommandAsync(EndAppointment);
            Initialize();
        }

        private void Initialize()
        {
            string patient = new ContextRepository<Patient>().GetItemById((uint) appointment.PatientId).ToStringForAppointment();
            page.PatientsSNP.Text = patient;
        }

        private async Task EndAppointment()
        {
            Note note = new(page.AppointmentTitleBox.Text, page.AppointmentTextBox.Text, DateTime.Now);
            Patient patient = await new ContextRepository<Patient>().GetItemByIdAsync((uint)appointment.PatientId);
            patient.Notes.Add(note);
            await new ContextRepository<Patient>().UpdateItemAsync(patient);

            mainPage.WorkspaceFrame.Content = null;
        }

        private void PrintNote() => OpenBrowserService.OpenPageInBrowser("https://www.youtube.com/watch?v=dQw4w9WgXcQ");
    }
}