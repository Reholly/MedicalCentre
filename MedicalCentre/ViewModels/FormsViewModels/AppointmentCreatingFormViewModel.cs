using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using MedicalCentre.Authentification;
using MedicalCentre.DatabaseLayer;
using MedicalCentre.Forms;
using MedicalCentre.Models;
using MedicalCentre.Services;
using MedicalCentre.ViewModels.Commands;

namespace MedicalCentre.ViewModels.FormsViewModels;

public class AppointmentCreatingFormViewModel
{
    public ICommand CreateCommand { get; set; }
    public ICommand CloseCommand { get; set; }

    private readonly AppointmentCreatingForm currentPage;
    private readonly ContextRepository<Appointment> appointmentDb = new ContextRepository<Appointment>();
    private readonly ContextRepository<Employee> doctorDb = new ContextRepository<Employee>();
    private readonly ContextRepository<Account> accountDb = new ContextRepository<Account>();
    public AppointmentCreatingFormViewModel(AppointmentCreatingForm page, List<Employee> doctors)
    {
        currentPage = page;
        CreateCommand = new RelayCommandAsync(Create);
        CloseCommand = new RelayCommand(() => currentPage.Close());
        currentPage.DoctorsList.ItemsSource = doctors;
    }

    private async Task Create()
    {
        try
        {
            var id = uint.Parse(currentPage.Id.Text);
            var employee = currentPage.DoctorsList.SelectedItem as Employee;
            var appointmentTime = DateTime.ParseExact(currentPage.AppointmentTime.Text, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);

            var appointment = new Appointment(id, employee.Id, appointmentTime);

            await Task.Run(() => appointmentDb.AddItemAsync(appointment));
            await Task.Run(() => LoggerService.CreateLog($"Created appointment {appointment.Id}", true));
        }
        catch (Exception ex)
        {
            await LoggerService.CreateLog(ex.Message, false);
        }
        currentPage.Close();
    }

    private async Task Init()
    {
        var accounts = await Task.Run(() => accountDb.GetTableAsync());
        var doctorsList = new List<Employee>();
        foreach (var account in accounts.Where(account => account.Role == Roles.Doctor))
        {
            var doctor = await Task.Run(() => doctorDb.GetItemByIdAsync(account.EmployeeAccountId));
            doctorsList.Add(doctor);
        }
        
        currentPage.DoctorsList.ItemsSource = doctorsList.ToArray();
    }
}