using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using MedicalCentre.DatabaseLayer;
using MedicalCentre.Models;
using MedicalCentre.Pages.DoctorWindowPages;
using MedicalCentre.Services;
using MedicalCentre.UserControls;
using MedicalCentre.ViewModels.Commands;
using MedicalCentre.Views;
using Microsoft.Extensions.DependencyInjection;

namespace MedicalCentre.ViewModels.UserControlsViewModels;

public class AppointmentCardViewModel
{
    private readonly Appointment appointment;
    private readonly DoctorMainPage page;
    private readonly DoctorWindow window;
    private readonly Account account;
    private readonly string patient;
    private readonly IRepository<Patient> patientRepository;
    private readonly IRepository<Note> noteRepository;
    private readonly IRepository<MedicalExamination> examsRepository;
    private readonly IRepository<Log> logRepository;
    private readonly IServiceProvider serviceProvider;
    public ICommand AppointmentStartingCommand { get; set; }
    public AppointmentCardViewModel(AppointmentCard card, Appointment appointment, DoctorMainPage page, string patient, string doctor, DoctorWindow window, Account account, IServiceProvider serviceProvider)
    {
        patientRepository = serviceProvider.GetRequiredService<IRepository<Patient>>();
        noteRepository = serviceProvider.GetRequiredService<IRepository<Note>>();
        examsRepository = serviceProvider.GetRequiredService<IRepository<MedicalExamination>>();
        logRepository = serviceProvider.GetRequiredService<IRepository<Log>>();

        this.serviceProvider = serviceProvider;
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
            var patient = await Task.Run( ()=> patientRepository.GetItemByIdAsync(appointment.PatientId?? throw new NullReferenceException()));
            page.WorkspaceFrame.Content = new AppointmentPage(appointment, window, account, serviceProvider);
            ShowNotes(patient);
            ShowExaminations(patient);
            await LoggerService.CreateLog($"Приём {appointment.Id} был начат", true, logRepository);
        }
        else
        {
            MessageBox.Show("Ты как приём без пациента начнёшь, шизоид?");
        }
    }

    private void ShowNotes(Patient patient)
    {
        page.PatientsNotes.Children.Clear();
        var notes = noteRepository.GetTable();
        foreach (var note in notes.Where(note => note.PatientId == patient.Id))
        {
            page.PatientsNotes.Children.Insert(0, new NoteCard(note));
        }
    }

    private void ShowExaminations(Patient patient)
    {
        page.PatientsExaminations.Children.Clear();
        var examinations = examsRepository.GetTable();
        foreach (var examination in examinations.Where(examination => examination.PatientId == patient.Id))
        {
            page.PatientsExaminations.Children.Insert(0, new ExaminationCard(examination));
        }
    }
}