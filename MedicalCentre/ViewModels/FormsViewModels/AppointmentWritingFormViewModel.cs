using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using MedicalCentre.DatabaseLayer;
using MedicalCentre.Forms;
using MedicalCentre.Models;
using MedicalCentre.Services;
using MedicalCentre.ViewModels.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace MedicalCentre.ViewModels.FormsViewModels;

public class AppointmentWritingFormViewModel
{
    public ICommand WriteCommand { get; set; }
    public ICommand CloseCommand { get; set; }

    private readonly AppointmentWritingForm currentPage;
    private readonly IRepository<Log> logRepository;
    private readonly IServiceProvider provider;
    public AppointmentWritingFormViewModel(AppointmentWritingForm page, IServiceProvider provider, List<Patient> patients, List<string> appointments)
    {
        currentPage = page;
        currentPage.Patient.ItemsSource = patients;
        currentPage.Appointment.ItemsSource = appointments;
        logRepository = provider.GetRequiredService<IRepository<Log>>();
        this.provider = provider;
        WriteCommand = new RelayCommandAsync(Write);
        CloseCommand = new RelayCommand(() => currentPage.Close());
    }

    private async Task Write()
    {
        try
        {
            var appointmentDb = provider.GetRequiredService<IRepository<Appointment>>();

            var patient = currentPage.Patient.SelectedItem as Patient;
            var appointmentId = ((currentPage.Appointment.SelectedItem as string)!).Split(" - ")[0];
            var appointment = await Task.Run(() => appointmentDb.GetItemByIdAsync(uint.Parse(appointmentId)));

            appointment!.PatientId = patient!.Id;
            await Task.Run(() => appointmentDb.UpdateItemAsync(appointment));
            await Task.Run(() => LoggerService.CreateLog($"patient {patient.Id} was recorded on {appointment.Id}", true, logRepository));
        }
        catch (Exception ex)
        {
            await LoggerService.CreateLog(ex.Message, false, logRepository);
        }
        currentPage.Close();
    }
}