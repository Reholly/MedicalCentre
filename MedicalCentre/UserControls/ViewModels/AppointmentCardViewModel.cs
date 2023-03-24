using MedicalCentre.Models;
using MedicalCentre.Pages.DoctorWindowPages;
using MedicalCentre.ViewModels;
using System.Windows;
using System.Windows.Input;
using MedicalCentre.DatabaseLayer;
using MedicalCentre.Windows;
using System.Windows.Documents;
using System.Collections.Generic;
using MedicalCentre.Services;
using System.Threading.Tasks;

namespace MedicalCentre.UserControls.ViewModels
{
    public class AppointmentCardViewModel
    {
        private readonly Appointment appointment;
        private readonly DoctorMainPage page;
        private readonly DoctorWindow window;
        private readonly Account account;
        private readonly string patient;
        public ICommand AppointmentStartingCommand { get; set; }
        public AppointmentCardViewModel(AppointmentCard card, Appointment appointment, DoctorMainPage page, string patient, string doctor, DoctorWindow window, Account account)
        {
            this.page = page;
            this.appointment = appointment;
            this.window = window;
            this.patient = patient;
            card.Card.Text = doctor + ": " + patient;
            AppointmentStartingCommand = new RelayCommandAsync(StartAppointment);
            this.account = account;
        }

        private async Task StartAppointment()
        {
            if (patient != "Тут_должен_быть_пациент")
            {
                Patient patient = new ContextRepository<Patient>().GetItemById((uint)appointment.PatientId);
                page.WorkspaceFrame.Content = new AppointmentPage(appointment, window, account);
                ShowNotes(patient);
                ShowExaminations(patient);
                await LoggerService.CreateLog($"Приём {appointment.Id} был начат", true);
            }
            else
            {
                MessageBox.Show("Ты как приём без пациента начнёшь, шизоид?");
            }
        }

        private void ShowNotes(Patient patient)
        {
            List<Note> notes = new ContextRepository<Note>().GetTable();
            foreach (Note note in notes)
            {
                if (note.PatientId == patient.Id)
                {
                    page.PatientsNotes.Children.Insert(0, new NoteCard(note));
                }
            }
        }

        private void ShowExaminations(Patient patient)
        {
            List<MedicalExamination> examinations = new ContextRepository<MedicalExamination>().GetTable();
            foreach (MedicalExamination examination in patient.Examinations)
            {
                if (examination.PatientId == patient.Id)
                {
                    page.PatientsExaminations.Children.Insert(0, new ExaminationCard(examination));
                }
            }
        }
    }
}