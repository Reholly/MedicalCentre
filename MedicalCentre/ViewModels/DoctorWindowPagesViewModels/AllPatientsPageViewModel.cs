using MedicalCentre.DatabaseLayer;
using MedicalCentre.Models;
using MedicalCentre.Pages.DoctorWindowPages;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;

namespace MedicalCentre.ViewModels.DoctorWindowPagesViewModels
{
    public class AllPatientsPageViewModel
    {
        private readonly Database<Patient> db = new();
        public ObservableCollection<Patient> Patients { get; set; }
        public Patient SelectedPatient { get; set; }
        public ICommand AddPatientCommand { get; set; }
        public ICommand DeletePatientCommand { get; set; }
        public ICommand ShowPatientInfoCommand { get; set; }
        public ICommand ShowTableCommand { get; set; }
        public AllPatientsPageViewModel()
        {
            ShowTableCommand = new RelayCommandAsync(ShowTable);
            AddPatientCommand = new RelayCommandAsync(AddPatient);
            DeletePatientCommand = new RelayCommandAsync(DeletePatient);
            ShowPatientInfoCommand = new RelayCommand(ShowPatientInfo);
        }

        private async Task ShowTable() => Patients = new(await db.GetTableAsync());

        private async Task AddPatient()
        {
            Patients = new(await db.GetTableAsync());
            Patient tempPatient = new();
            Patients.Add(tempPatient);
            await db.AddItemAsync(tempPatient);
        }

        private async Task DeletePatient()
        {
            Patients = new(await db.GetTableAsync());
            Patient tempPatient = SelectedPatient;
            await db.DeleteItemAsync(tempPatient);
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