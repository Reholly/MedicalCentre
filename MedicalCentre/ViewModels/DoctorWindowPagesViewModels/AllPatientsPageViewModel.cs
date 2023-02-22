using MedicalCentre.Models;
using MedicalCentre.Pages.DoctorWindowPages;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Navigation;

namespace MedicalCentre.ViewModels.DoctorWindowPagesViewModels
{
    public class AllPatientsPageViewModel 
    {
        public ObservableCollection<Patient> Patients { get; set; } = new();
        public Patient SelectedPatient { get; set; }
        public ICommand AddPatientCommand { get; set; }
        public ICommand DeletePatientCommand { get; set; }
        public ICommand ShowPatientInfoCommand { get; set; }
        public AllPatientsPageViewModel()
        {
            AddPatientCommand = new RelayCommand(AddPatient);
            DeletePatientCommand = new RelayCommand(DeletePatient);
            ShowPatientInfoCommand = new RelayCommand(ShowPatientInfo);
        }

        private void AddPatient() => Patients.Add(new Patient());
        private void DeletePatient() => Patients.Remove(SelectedPatient);
        private void ShowPatientInfo()
        {
            NavigationWindow window = new NavigationWindow();
            window.Content = new PatientInfoPage(SelectedPatient);
            window.Show();
        }
    }
}