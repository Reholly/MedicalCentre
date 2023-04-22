using MedicalCentre.DatabaseLayer;
using MedicalCentre.Models;
using MedicalCentre.Pages.DoctorWindowPages;
using MedicalCentre.Services;
using MedicalCentre.ViewModels;
using MedicalCentre.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MedicalCentre.UserControls.ViewModels;

public class AppointmentCardViewModel
{
    private readonly Appointment appointment;
    private readonly DoctorMainPage page;
    private readonly DoctorWindow window;
    private readonly Account account;
    private readonly string patient;
    private IRepository<Patient> patientRepository;
    private IRepository<Note> noteRepository;
    private IRepository<MedicalExamination> examsRepository;
    private IServiceProvider serviceProvider;
    public ICommand AppointmentStartingCommand { get; set; }
    public AppointmentCardViewModel(AppointmentCard card, Appointment appointment, DoctorMainPage page, string patient, string doctor, DoctorWindow window, Account account, IServiceProvider serviceProvider)
    {
        this.patientRepository = serviceProvider.GetRequiredService<IRepository<Patient>>();
        this.noteRepository = serviceProvider.GetRequiredService<IRepository<Note>>();
        this.examsRepository = serviceProvider.GetRequiredService<IRepository<MedicalExamination>>();

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
            Patient patient = await Task.Run( ()=> patientRepository.GetItemByIdAsync((uint)appointment.PatientId));
            page.WorkspaceFrame.Content = new AppointmentPage(appointment, window, account, serviceProvider);
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
        page.PatientsNotes.Children.Clear();
        List<Note> notes = noteRepository.GetTable();
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
        page.PatientsExaminations.Children.Clear();
        List<MedicalExamination> examinations = examsRepository.GetTable();
        foreach (MedicalExamination examination in examinations)
        {
            if (examination.PatientId == patient.Id)
            {
                page.PatientsExaminations.Children.Insert(0, new ExaminationCard(examination));
            }
        }
    }
}