using MedicalCentre.DatabaseLayer;
using MedicalCentre.Models;
using MedicalCentre.Pages.DoctorWindowPages;
using MedicalCentre.Services;
using MedicalCentre.ViewModels;
using MedicalCentre.Windows;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MedicalCentre.UserControls.ViewModels
{
    public class AppointmentCardViewModel
    {
        private readonly Appointment appointment;
        private readonly DoctorMainPage page;
        private readonly DoctorWindow window;
        private readonly Account account;
        private readonly string patient;
        private readonly ContextRepository<Patient> _repositoryPatients;
        private readonly ContextRepository<Note> _repositoyrNotes;
        private readonly ContextRepository<MedicalExamination> _repositoryExaminations;
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
            _repositoryPatients= new ContextRepository<Patient>();
            _repositoyrNotes = new ContextRepository<Note>();
            _repositoryExaminations = new ContextRepository<MedicalExamination>();
        }

        private async Task StartAppointment()
        {
            if (patient != "Тут_должен_быть_пациент")
            {
                Patient patient = await _repositoryPatients.GetItemByIdAsync((uint)appointment.PatientId);
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

        private async Task ShowNotes(Patient patient)
        {
            page.PatientsNotes.Children.Clear();
            List<Note> notes = await _repositoyrNotes.GetTableAsync();
            foreach (Note note in notes)
            {
                if (note.PatientId == patient.Id)
                {
                    page.PatientsNotes.Children.Insert(0, new NoteCard(note));
                }
            }
        }

        private async Task ShowExaminations(Patient patient)
        {
            page.PatientsExaminations.Children.Clear();
            List<MedicalExamination> examinations = await _repositoryExaminations.GetTableAsync();
            foreach (MedicalExamination examination in examinations)
            {
                if (examination.PatientId == patient.Id)
                {
                    page.PatientsExaminations.Children.Insert(0, new ExaminationCard(examination));
                }
            }
        }
    }
}