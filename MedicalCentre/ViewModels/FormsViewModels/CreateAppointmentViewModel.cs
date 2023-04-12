﻿using MedicalCentre.DatabaseLayer;
using MedicalCentre.Forms;
using MedicalCentre.Models;
using MedicalCentre.Services;
using MedicalCentre.ViewModels;
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
    private ContextRepository<Appointment> appointmentDb = new ContextRepository<Appointment>();
    private ContextRepository<Employee> doctorDb = new ContextRepository<Employee>();
    public CreateAppointmentViewModel(CreateAppointment page)
    {
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
            await LoggerService.CreateLog($"Created appointment {appointment.Id}", true);
        }
        catch (Exception ex)
        {
            await LoggerService.CreateLog(ex.Message, false);
        }
        currentPage.Close();
    }
}

