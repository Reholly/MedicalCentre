using MedicalCentre.DatabaseLayer;
using MedicalCentre.Models;
using MedicalCentre.Pages.DoctorWindowPages;
using SciChart.Core.Extensions;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;

namespace MedicalCentre.ViewModels.DoctorWindowPagesViewModels
{
    public class AllPatientsPageViewModel
    {
        public ObservableCollection<Patient> Patients { get; set; } = null!;
        public Patient? SelectedPatient { get; set; }
        public ICommand AddPatientCommand { get; set; }
        public ICommand DeletePatientCommand { get; set; }
        public ICommand ShowPatientInfoCommand { get; set; }
        public ICommand InitializeTableCommand { get; set; }
        public AllPatientsPageViewModel()
        {
            AddPatientCommand = new RelayCommandAsync(AddPatient);
            DeletePatientCommand = new RelayCommandAsync(DeletePatient);
            ShowPatientInfoCommand = new RelayCommand(ShowPatientInfo);
            InitializeTableCommand = new RelayCommandAsync(InitializeTable);
        }

        private async Task InitializeTable() //обновление таблицы
        {
            ContextRepository<Patient> repository = new();
            Patients = new ObservableCollection<Patient>(await repository.GetTableAsync());
        }

        private async Task AddPatient() //добавление пациента
        {
            Patient tempPatient = new();
            Patients.Add(tempPatient);
            ContextRepository <Patient> database = new();
            await database.AddItemAsync(tempPatient);
        }
        private async Task DeletePatient() //удаление пациента
        {
            ContextRepository<Patient> database = new();
            Patient? tempPatient = SelectedPatient;
            await database.DeleteItemAsync(tempPatient);
            Patients.Remove(tempPatient);
        }

        private void ShowPatientInfo()
        {
            if (SelectedPatient != null)
            {
                NavigationWindow window = new()
                {
                    Content = new PatientInfoPage(SelectedPatient)
                };
                window.Show();
            }
        }
    }
}