using MedicalCentre.DatabaseLayer;
using MedicalCentre.Models;
using MedicalCentre.Pages.DoctorWindowPages;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
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
            AddPatientCommand = new RelayCommandAsync(AddPatient);
            DeletePatientCommand = new RelayCommandAsync(DeletePatient);
            ShowPatientInfoCommand = new RelayCommand(ShowPatientInfo);
        }

        private async Task AddPatient()
        {
            Patient tempPatient = new();
            Patients.Add(tempPatient);
            Database <Patient> database = new();
            await database.AddItemAsync(tempPatient);
        }
        private async Task DeletePatient()
        {
            Database<Patient> database = new();
            Patient tempPatient = SelectedPatient;
            await database.DeleteItemAsync(tempPatient);
            Patients.Remove(tempPatient);
        }

        private void ShowPatientInfo()
        {
            if (SelectedPatient != null)
            {
                NavigationWindow window = new();
                window.Content = new PatientInfoPage(SelectedPatient);
                window.Show();
            }
        }
    }
}