using MedicalCentre.DatabaseLayer;
using MedicalCentre.Models;
using MedicalCentre.Pages.DoctorWindowPages;
using MedicalCentre.Services;
using System.Threading.Tasks;
using System.Windows.Input;
using System;
using MedicalCentre.Windows;

namespace MedicalCentre.ViewModels.DoctorWindowPagesViewModels
{
    public class AppointmentPageViewModel
    {
        private readonly Appointment appointment;
        private readonly AppointmentPage page;
        private readonly DoctorWindow window;
        private readonly Account account;
        public ICommand NotePrintingCommand { get; set; }
        public ICommand AppointmentEndingCommand { get; set; }
        public AppointmentPageViewModel(Appointment appointment, AppointmentPage page, DoctorWindow window, Account account)
        {
            this.appointment = appointment;
            this.page = page;
            this.window = window;
            NotePrintingCommand = new RelayCommand(PrintNote);
            AppointmentEndingCommand = new RelayCommandAsync(EndAppointment);
            Initialize();
            this.account = account;
        }

        private void Initialize()
        {
            string patient = new ContextRepository<Patient>().GetItemById((uint)appointment.PatientId).ToStringForAppointment();
            page.PatientsSNP.Text = patient;
        }

        private async Task EndAppointment()
        {
            Note note = new(page.AppointmentTitleBox.Text, page.AppointmentTextBox.Text, DateTime.Now);
            Patient patient = await new ContextRepository<Patient>().GetItemByIdAsync((uint)appointment.PatientId);
            patient.Notes.Add(note);
            await new ContextRepository<Patient>().UpdateItemAsync(patient);

            appointment.IsFinished = true;
            //await new ContextRepository<Appointment>().UpdateItemAsync(appointment);

            window.MainFrame.Content = new DoctorMainPage(window, account);
        }

        private void PrintNote() => OpenBrowserService.OpenPageInBrowser("https://www.youtube.com/watch?v=dQw4w9WgXcQ");
    }
}