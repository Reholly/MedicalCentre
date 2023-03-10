using MedicalCentre.DatabaseLayer;
using MedicalCentre.Forms;
using MedicalCentre.Models;
using MedicalCentre.Pages.AdminWindowPages;
using MedicalCentre.Services;
using MedicalCentre.UserControls;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MedicalCentre.ViewModels.AdminWindowPagesViewModels
{
    public class PatientsViewModel
    {
        public ObservableCollection<Patient> Patients { get; set; } = new();
        public ICommand? SearchCommand { get; set; }
        public ICommand? OpenRegistrationCommand { get; set; }
        public ICommand? OpenNewsCommand { get; set; }

        private PatientsPage page;
        public PatientsViewModel(PatientsPage page)
        {
            this.page = page;
            SearchCommand = new RelayCommandAsync(SearchItems);

            OpenRegistrationCommand = new RelayCommand(OpenRegistration);
            OpenNewsCommand = new RelayCommand(OpenNews);
            page.Search.TextChanged += OnTextChanged;

            SearchItems();
        }

        public void OpenNews()
        {
            MessageBox.Show("ЭТО ЗАГЛУШКА");
        }

        public void OpenRegistration()
        {
            PatientRegistration patientRegister = new();
            patientRegister.Show();
        }

        public async Task SearchItems()
        {
            ContextRepository<Patient> patientsDb = new();
            Patients = new ObservableCollection<Patient>(await patientsDb.GetTableAsync());
            Patients = new ObservableCollection<Patient>(SearchFilterService<Patient>.GetFilteredList(Patients.ToList(), page.Search.Text));
            page.PatientsCards.Children.Clear();
            foreach (var patient in Patients)
            {
                page.PatientsCards.Children.Insert(0, new PatientCard(patient));
            }
        }

        private void OnTextChanged(object sender, TextChangedEventArgs args)
        {
            SearchItems();
        }
    }
}