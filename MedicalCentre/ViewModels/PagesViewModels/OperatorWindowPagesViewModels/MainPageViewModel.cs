using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using MedicalCentre.Authentification;
using MedicalCentre.Forms;
using MedicalCentre.Models;
using MedicalCentre.Services;
using System;
using System.Linq;
using MedicalCentre.DatabaseLayer;
using MedicalCentre.ViewModels.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace MedicalCentre.ViewModels.PagesViewModels.OperatorWindowPagesViewModels;

public class MainPageViewModel
{
    public ICommand OpenNewsCommand { get; set; }
    public ICommand OpenNewFeaturesCommand { get; set; }
    public ICommand WriteCommand { get; set; }
    public ICommand CreateCommand { get; set; }
    
    private readonly IServiceProvider serviceProvider;
    public MainPageViewModel(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;

        OpenNewsCommand = new RelayCommand(OpenNews);
        OpenNewFeaturesCommand = new RelayCommand(OpenNewFeatures);
        CreateCommand = new RelayCommandAsync(Create);
        WriteCommand = new RelayCommandAsync(Write);
    }

    private void OpenNews() => OpenBrowserService.OpenPageInBrowser(Properties.Settings.Default.OpenInvalidSite);
    
    private void OpenNewFeatures() => OpenBrowserService.OpenPageInBrowser(Properties.Settings.Default.NewFeatures);
    

    private async Task Create()
    {
        var doctorsList = await Task.Run(InitDoctors);
        var window = new AppointmentCreatingForm(doctorsList, serviceProvider);
        window.Show();
    }

    private async Task Write()
    {
        var patientsList = await Task.Run(InitPatients);
        var appointmentsList = await Task.Run(InitAppointments);
        var window = new AppointmentWritingForm(serviceProvider, patientsList, appointmentsList);
        window.Show();
    }

    private async Task<List<Employee>> InitDoctors()
    {
        var accounts = await Task.Run(() => serviceProvider.GetRequiredService<IRepository<Account>>().GetTableAsync());
        var doctorsList = new List<Employee>();
        foreach (var account in accounts.Where(account => account.Role == Roles.Doctor))
        {
            var doctor = await Task.Run(() => serviceProvider.GetRequiredService<IRepository<Employee>>().GetItemByIdAsync(account.EmployeeAccountId));
            doctorsList.Add(doctor);
        }

        return doctorsList;
    }

    private async Task<List<Patient>> InitPatients()
    {
        var patientsDb = serviceProvider.GetRequiredService<IRepository<Patient>>();
        var patients = await Task.Run(() => patientsDb.GetTableAsync());
        return patients;
    }

    private async Task<List<string>> InitAppointments()
    {
        var appointments = await Task.Run(() =>
            serviceProvider.GetRequiredService<IRepository<Appointment>>().GetTableAsync());
        var result = new List<string>();
        foreach (var appointment in appointments.Where(a => a is { IsFinished: false, PatientId: null } && a.AppointmentTime.Date >= DateTime.Today.Date))
        {
            var doctor = await Task.Run(() => serviceProvider.GetRequiredService<IRepository<Employee>>().GetItemByIdAsync(appointment.DoctorId));
            result.Add($"{appointment.Id} - {doctor.Surname} - {doctor.Specialization} - {appointment.AppointmentTime}");
        }

        return result;
    }
}