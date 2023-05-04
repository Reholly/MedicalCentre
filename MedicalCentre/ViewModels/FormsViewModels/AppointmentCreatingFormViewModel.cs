using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Input;
using MedicalCentre.DatabaseLayer;
using MedicalCentre.Forms;
using MedicalCentre.Models;
using MedicalCentre.Services;
using MedicalCentre.ViewModels.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace MedicalCentre.ViewModels.FormsViewModels;

public class AppointmentCreatingFormViewModel
{
    public ICommand CreateCommand { get; set; }
    public ICommand CloseCommand { get; set; }

    private readonly AppointmentCreatingForm currentPage;
    private readonly IServiceProvider provider;

    public AppointmentCreatingFormViewModel(AppointmentCreatingForm page, List<Employee> doctors, IServiceProvider provider)
    {
        currentPage = page;
        this.provider = provider;
        CreateCommand = new RelayCommandAsync(Create);
        CloseCommand = new RelayCommand(() => currentPage.Close());
        currentPage.DoctorsList.ItemsSource = doctors;
    }

    private async Task Create()
    {
        try
        {
            var employee = currentPage.DoctorsList.SelectedItem as Employee;
            var appointmentTime = DateTime.ParseExact(currentPage.AppointmentTime.Text, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);

            var appointment = new Appointment(employee!.Id, appointmentTime);

            await Task.Run(() => provider.GetRequiredService<IRepository<Appointment>>().AddItemAsync(appointment));
            await Task.Run(() => LoggerService.CreateLog($"Created appointment {appointment.Id}", true, provider.GetRequiredService<IRepository<Log>>()));
        }
        catch (Exception ex)
        {
            await LoggerService.CreateLog(ex.Message, false, provider.GetRequiredService<IRepository<Log>>());
        }
        currentPage.Close();
    }
}