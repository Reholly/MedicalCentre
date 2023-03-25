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
        private readonly DoctorMainPage _page;
        private readonly DoctorWindow _window;
        private readonly Account _account;
        private readonly ContextRepository<Patient> _repositoryPatients;
        private readonly ContextRepository<Employee> _repositoryEmployees;
        private readonly ContextRepository<Appointment> _repositoryAppointments;

        public DoctorMainPageViewModel(DoctorMainPage page, DoctorWindow window, Account account)
        {
            this._page = page;
            this._window = window;
            this._account = account;
            _repositoryPatients = new ContextRepository<Patient>();
            _repositoryEmployees = new ContextRepository<Employee>();
            _repositoryAppointments = new ContextRepository<Appointment>();
            ShowCards();
        }

        private async Task ShowCards()
        {
            List<Appointment> appointments = await _repositoryAppointments.GetTableAsync();
            foreach (Appointment appointment in appointments)
            {
                if (appointment.IsFinished == false && appointment.AppointmentTime.Date == DateTime.Today.Date)
                {
                    Patient patient;
                    string patientString;

                    if (appointment.PatientId != null)
                    {
                        patient = await _repositoryPatients.GetItemByIdAsync((uint)appointment.PatientId);
                        patientString = patient.ToStringForAppointment();
                    }
                    else
                    {
                        patientString = "Тут_должен_быть_пациент";
                    }

                    Employee doctor = await _repositoryEmployees.GetItemByIdAsync(appointment.DoctorId);
                    string doctorString = doctor.ToString();

                    if (_account.EmployeeAccountId == appointment.DoctorId)
                    {
                        _page.AppointmentCards.Children.Insert(0, new AppointmentCard(appointment, _page, patientString, doctorString, _window, _account));
                    }
                }
            }
        }
    }
}