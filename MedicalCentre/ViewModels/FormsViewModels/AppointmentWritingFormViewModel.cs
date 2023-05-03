using System;
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
    public AppointmentWritingFormViewModel(AppointmentWritingForm page, IServiceProvider provider)
    {
        currentPage = page;
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
            var patientDb = provider.GetRequiredService<IRepository<Patient>>();

            var patient = await patientDb.GetItemByIdAsync(uint.Parse(currentPage.PatientId.Text));
            var appointment = await appointmentDb.GetItemByIdAsync(uint.Parse(currentPage.AppointmentId.Text));

            appointment.PatientId = patient.Id;
            await appointmentDb.UpdateItemAsync(appointment);
            await LoggerService.CreateLog($"patient {patient.Id} was recorded on {appointment.Id}", true, logRepository);
        }
        catch (Exception ex)
        {
            await LoggerService.CreateLog(ex.Message, false, logRepository);
        }
        currentPage.Close();
    }
}