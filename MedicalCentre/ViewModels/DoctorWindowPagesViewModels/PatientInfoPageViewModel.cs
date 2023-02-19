using MedicalCentre.Models;
using MedicalCentre.Pages.DoctorWindowPages;
using MedicalCentre.Services;
using System.Windows.Input;

namespace MedicalCentre.ViewModels.DoctorWindowPagesViewModels
{
    public class PatientInfoPageViewModel
    {
        private readonly PatientInfoPage page;
        public Patient CurrentPatient { get; set; }
        public ICommand ViewPatientsNotesCommand { get; set; }

        public PatientInfoPageViewModel(Patient patient, PatientInfoPage page)
        {
            CurrentPatient = patient;
            this.page = page;
            ViewPatientsNotesCommand = new RelayCommand(ViewPatientsNotes);
        }
        private void ViewPatientsNotes()
        {
            page.LeftFrame.Content = new PatientsNotesPage(CurrentPatient.Notes);
        }
    }
}
