using MedicalCentre.DatabaseLayer;
using MedicalCentre.Models;
using MedicalCentre.Pages.DoctorWindowPages;
using MedicalCentre.UserControls;
using MedicalCentre.Windows;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicalCentre.ViewModels.DoctorWindowPagesViewModels
{
    public class DoctorMainPageViewModel
    {
        private readonly DoctorMainPage page;
        private readonly DoctorWindow window;
        private readonly Account account;

        public DoctorMainPageViewModel(DoctorMainPage page, DoctorWindow window, Account account)
        {
            this.page = page;
            this.window = window;
            this.account = account;
            ShowCards();
        }

        private async Task ShowCards()
        {
            List<Appointment> appointments = await new ContextRepository<Appointment>().GetTableAsync();
            foreach (Appointment appointment in appointments)
            {
                if (appointment.IsFinished == false && appointment.AppointmentTime.Date == DateTime.Today.Date)
                {
                    Patient patient;
                    string patientString;

                    if (appointment.PatientId != null)
                    {
                        patient = new ContextRepository<Patient>().GetItemById((uint)appointment.PatientId);
                        patientString = patient.ToStringForAppointment();
                    }
                    else
                    {
                        patientString = "Тут_должен_быть_пациент";
                    }

                    Employee doctor = new ContextRepository<Employee>().GetItemById(appointment.DoctorId);
                    string doctorString = doctor.ToString();

                    if (account.EmployeeAccountId == appointment.DoctorId)
                    {
                        page.AppointmentCards.Children.Insert(0, new AppointmentCard(appointment, page, patientString, doctorString, window, account));
                    }
                }
            }
        }
    }
}