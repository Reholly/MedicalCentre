using MedicalCentre.DatabaseLayer;
using MedicalCentre.Forms;
using MedicalCentre.Models;
using MedicalCentre.Services;
using MedicalCentre.ViewModels;
using MedicalCentre.ViewModels.Commands;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MedicalCentre.FormsViewModels;

public class CreateAppointmentViewModel
{
    public ICommand CreateCommand { get; set; }
    public ICommand CloseCommand { get; set; }

    private CreateAppointment currentPage;
    private readonly IRepository<Appointment> appointmentDb;
    private readonly IRepository<Employee> doctorDb;
    private readonly IRepository<Log> logDb;    
    public CreateAppointmentViewModel(CreateAppointment page, IServiceProvider serviceProvider)
    {
        appointmentDb = serviceProvider.GetRequiredService<IRepository<Appointment>>();
        doctorDb = serviceProvider.GetRequiredService<IRepository<Employee>>();
        logDb = serviceProvider.GetRequiredService<IRepository<Log>>();

        currentPage = page;
        CreateCommand = new RelayCommandAsync(Create);
        CloseCommand = new RelayCommand(() => currentPage.Close());
    }

    private async Task Create()
    {
        try
        {
            uint id = uint.Parse(currentPage.Id.Text);
            uint doctorId = uint.Parse(currentPage.DoctorId.Text);
            DateTime appointmentTime = DateTime.ParseExact(currentPage.AppointmentTime.Text, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);

            Employee employee = await doctorDb.GetItemByIdAsync(doctorId);


            Appointment appointment = new Appointment(id, employee.Id, appointmentTime);

            await appointmentDb.AddItemAsync(appointment);
            await LoggerService.CreateLog($"Created appointment {appointment.Id}", true, logDb);
        }
        catch (Exception ex)
        {
            await LoggerService.CreateLog(ex.Message, false, logDb);
        }
        currentPage.Close();
    }
}

