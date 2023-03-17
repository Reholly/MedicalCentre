using MedicalCentre.DatabaseLayer;
using MedicalCentre.Models;
using MedicalCentre.Pages.DoctorWindowPages;
using MedicalCentre.UserControls;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System;

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

        private async Task ShowCards()
        {
            ContextRepository<Appointment> appointmentRepository = new();
            ContextRepository<Patient> patientRepository = new();
            ContextRepository<Employee> employeeRepository = new();
            Appointments = new ObservableCollection<Appointment>(await appointmentRepository.GetTableAsync());
            int count = 0;
            page.AppointmentCards.Children.Clear();
            foreach (Appointment appointment in Appointments)
            {
                string patient = patientRepository.GetItemByIdAsync((uint)appointment.PatientId).Result.ToStringForAppointment();
                string doctor = employeeRepository.GetItemByIdAsync(appointment.DoctorId).Result.ToString();
                page.AppointmentCards.Children.Insert(count, new AppointmentCard(appointment, page, patient, doctor));
                count++;
            }
        }
    }
}