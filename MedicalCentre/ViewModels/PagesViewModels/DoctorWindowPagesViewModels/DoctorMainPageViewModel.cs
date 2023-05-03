using System;
using System.Threading.Tasks;
using MedicalCentre.DatabaseLayer;
using MedicalCentre.Models;
using MedicalCentre.Pages.DoctorWindowPages;
using MedicalCentre.UserControls;
using MedicalCentre.Views;
using Microsoft.Extensions.DependencyInjection;

namespace MedicalCentre.ViewModels.PagesViewModels.DoctorWindowPagesViewModels;

public class DoctorMainPageViewModel
{
    private readonly DoctorMainPage page;
    private readonly DoctorWindow window;
    private readonly Account account;
    private readonly IServiceProvider serviceProvider;

    public DoctorMainPageViewModel(DoctorMainPage page, DoctorWindow window, Account account, IServiceProvider serviceProvider)
    {
        this.page = page;
        this.window = window;
        this.serviceProvider = serviceProvider;
        this.account = account;

        ShowCards();
    }

    private async Task ShowCards()
    {
        var appDb = serviceProvider.GetRequiredService<IRepository<Appointment>>();
        var appointments = await Task.Run(() => appDb.GetTableAsync());
        foreach (var appointment in appointments)
        {
            if (appointment.IsFinished == false && appointment.AppointmentTime.Date == DateTime.Today.Date)
            {
                Patient patient;
                string patientString;

                if (appointment.PatientId != null)
                {
                    var patientsDb = serviceProvider.GetRequiredService<IRepository<Patient>>();
                    patient = patientsDb.GetItemById((uint)appointment.PatientId);
                    patientString = patient.ToStringForAppointment();
                }
                else
                {
                    patientString = "Тут_должен_быть_пациент";
                }

                var empDb = serviceProvider.GetRequiredService<IRepository<Employee>>();
                var doctor = empDb.GetItemById(appointment.DoctorId);
                var doctorString = doctor.ToString();

                if (account.EmployeeAccountId == appointment.DoctorId)
                {
                    page.AppointmentCards.Children.Insert(0, new AppointmentCard(appointment, page, patientString, doctorString, window, account,serviceProvider));
                }
            }
        }
    }
}