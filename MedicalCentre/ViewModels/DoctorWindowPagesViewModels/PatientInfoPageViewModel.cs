using MedicalCentre.DatabaseLayer;
using MedicalCentre.Models;
using MedicalCentre.Pages.DoctorWindowPages;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MedicalCentre.ViewModels.DoctorWindowPagesViewModels
{
    public class PatientInfoPageViewModel
    {
        private readonly PatientInfoPage page;
        public Patient CurrentPatient { get; set; }
        public ICommand ViewPatientsNotesCommand { get; set; }
        public ICommand ViewPatientsExaminationsCommand { get; set; }
        public ICommand CreateNoteCommand { get; set; }
        public ICommand CreateExaminationCommand { get; set; }

        public PatientInfoPageViewModel(Patient patient, PatientInfoPage page)
        {
            CurrentPatient = patient;
            this.page = page;
            ViewPatientsNotesCommand = new RelayCommand(ViewPatientsNotes);
            ViewPatientsExaminationsCommand = new RelayCommand(ViewPatientExaminations);
            CreateNoteCommand = new RelayCommandAsync(CreateNote);
            CreateExaminationCommand = new RelayCommandAsync(CreateExaminationAsync);
        }

        private void ViewPatientsNotes() => page.LeftFrame.Content = new PatientsNotesPage(CurrentPatient.Notes);
        private void ViewPatientExaminations() => page.LeftFrame.Content = new PatientExaminationsPage(CurrentPatient.Examinations);
        private async Task CreateNote()
        {
            CreateNotePage notePage = new();
            page.RightFrame.Content = notePage;
            Note note = new();
            if (notePage.IsCreated)
                note = notePage.CreatedNote;
            CurrentPatient.Notes.Add(note);
            Database<Patient> database = new();
            await database.UpdateItemAsync(CurrentPatient);
        }
        private async Task CreateExaminationAsync()
        {
            CreateExaminationPage Page = new(CurrentPatient);
            page.RightFrame.Content = Page;
            MedicalExamination examination = new();
            if (Page.IsCreated)
                examination = Page.CreatedExamination;
            CurrentPatient.Examinations.Add(examination);
            Database<Patient> database = new();
            await database.UpdateItemAsync(CurrentPatient);
        }
    }
}