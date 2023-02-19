using MedicalCentre.Models;
using MedicalCentre.Pages.DoctorWindowPages;

namespace MedicalCentre.ViewModels.DoctorWindowPagesViewModels
{
    public class PatientInfoPageViewModel
    {
        private readonly PatientInfoPage page;
        public Patient CurrentPatient { get; set; }

        public PatientInfoPageViewModel(Patient patient, PatientInfoPage page)
        {
            CurrentPatient = patient;
            this.page = page;
        }
    }
}
