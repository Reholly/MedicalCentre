using MedicalCentre.Models;
using MedicalCentre.Pages.DoctorWindowPages;
using MedicalCentre.ViewModels;
using System.Windows;
using System.Windows.Input;
using MedicalCentre.DatabaseLayer;
using MedicalCentre.Windows;

namespace MedicalCentre.UserControls.ViewModels
{
    public class AppointmentCardViewModel
    {
        private readonly Appointment appointment;
        private readonly DoctorMainPage page;
        private readonly DoctorWindow window;
        private readonly Account account;
        private readonly string patient;
        private readonly string doctor;
        public ICommand AppointmentStartingCommand { get; set; }
        public AppointmentCardViewModel(AppointmentCard card, Appointment appointment, DoctorMainPage page, string patient, string doctor, DoctorWindow window, Account account)
        {
            this.page = page;
            this.appointment = appointment;
            this.window = window;
            this.patient = patient;
            this.doctor = doctor;
            card.Card.Text = doctor + ": " + patient;
            AppointmentStartingCommand = new RelayCommand(StartAppointment);
            this.account = account;
        }

        private void StartAppointment()
        {
            if (patient != "Тут_должен_быть_пациент")
            {
                Patient patient = new ContextRepository<Patient>().GetItemById((uint)appointment.PatientId);
                page.WorkspaceFrame.Content = new AppointmentPage(appointment, window, account);
                ShowNotes(patient);
                ShowExaminations(patient);
            }
            else
                MessageBox.Show("Ты как приём без пациента начнёшь, шизоид?");
        }

        private void ShowNotes(Patient patient)
        {
            foreach (Note note in patient.Notes)
            {
                page.PatientsNotes.Children.Insert(0, new NoteCard(note));
            }
        }

        private void ShowExaminations(Patient patient)
        {
            foreach (MedicalExamination examination in patient.Examinations)
            {
                page.PatientsExaminations.Children.Insert(0, new ExaminationCard(examination));
            }
        }
    }
}