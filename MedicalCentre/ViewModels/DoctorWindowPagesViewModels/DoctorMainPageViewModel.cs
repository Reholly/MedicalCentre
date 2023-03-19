using MedicalCentre.DatabaseLayer;
using MedicalCentre.Models;
using MedicalCentre.Pages.DoctorWindowPages;
using MedicalCentre.UserControls;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace MedicalCentre.ViewModels.DoctorWindowPagesViewModels
{
    public class DoctorMainPageViewModel
    {
        private readonly DoctorMainPage page;
        public DoctorMainPageViewModel(DoctorMainPage page)
        {
            this.page = page;
            ShowCards();
        }

        private void ShowCards()
        {
            List<Appointment> appointments = new ContextRepository<Appointment>().GetTable();
            foreach (Appointment appointment in appointments)
            {
                Patient patient;
                string patientString;

                if (appointment.PatientId != null)
                {
                    patient = new ContextRepository<Patient>().GetItemById((uint)appointment.PatientId);
                    patientString = patient.ToStringForAppointment();
                }
                else
                    patientString = "Тут_должен_быть_пациент";

                Employee doctor = new ContextRepository<Employee>().GetItemById(appointment.DoctorId);
                string doctorString;

                if (doctor == null)
                    doctorString = "Тут_должен_быть_врач";
                else
                    doctorString = doctor.ToString();

                page.AppointmentCards.Children.Insert(0, new AppointmentCard(appointment, page, patientString, doctorString));
            }
        }
    }
}