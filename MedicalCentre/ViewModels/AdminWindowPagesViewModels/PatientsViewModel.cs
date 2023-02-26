using MedicalCentre.DatabaseLayer;
using MedicalCentre.Forms;
using MedicalCentre.Models;
using MedicalCentre.Pages.AdminWindowPages;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace MedicalCentre.ViewModels.AdminWindowPagesViewModels
{
    public class PatientsViewModel
    {
        public ObservableCollection<Patient> Patients { get; set; } = new();
        public ICommand? ShowTableCommand { get; set; }
        public ICommand? DeleteCommand { get; set; }
        private Patients page;
        public PatientsViewModel(Patients page)
        {
            this.page = page;
            ShowTableCommand = new RelayCommand(ShowTable);
            DeleteCommand = new RelayCommand(DeletePatient);
        }

        private async void ShowTable()
        {
            Database<Patient> patientDb = new Database<Patient>();

            var patients = await patientDb.GetTableAsync();
            Patients = new ObservableCollection<Patient>(patients);

            page.PatientsGrid.ItemsSource = Patients;
            page.PatientsGrid.Visibility = Visibility.Visible;
        }

        private void DeletePatient()
        {
            DeletePatient window = new DeletePatient();
            window.Show();
        }
    }
}
