using MedicalCentre.DatabaseLayer;
using MedicalCentre.Models;
using MedicalCentre.Pages.DoctorWindowPages;
using MedicalCentre.UserControls;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MedicalCentre.ViewModels.DoctorWindowPagesViewModels
{
    public class DoctorMainPageViewModel
    {
        private readonly MainPage page;
        public ObservableCollection<Appointment> Appointments { get; set; } = new();
        public DoctorMainPageViewModel(MainPage page)
        {
            this.page = page;
            ShowCards();
        }

        private void ShowCards()
        {
            ContextRepository<Appointment> appointmentRepository = new();
            ContextRepository<Patient> patientRepository = new();
            ContextRepository<Employee> employeeRepository = new();
            List<Appointment> appointments = appointmentRepository.GetTable();
            foreach (Appointment appointment in appointments)
            {
                string patient;
                if (appointment.PatientId == null)
                    patient = "*Тут должен быть пациент*";
                else
                    patient = patientRepository.GetItemById((uint)appointment.PatientId).ToStringForAppointment();
                Employee employee = employeeRepository.GetItemById(appointment.DoctorId);
                string doctor;
                if (employee == null)
                    doctor = "*Тут должен быть врач*";
                else
                    doctor = employee.ToString();
                page.AppointmentCards.Children.Insert(0, new AppointmentCard(appointment, page, patient, doctor));
            }
        }
    }
}