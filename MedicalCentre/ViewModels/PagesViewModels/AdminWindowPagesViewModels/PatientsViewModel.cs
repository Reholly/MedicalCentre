using MedicalCentre.DatabaseLayer;
using MedicalCentre.Forms;
using MedicalCentre.Models;
using MedicalCentre.Pages.AdminWindowPages;
using MedicalCentre.Services;
using MedicalCentre.UserControls;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace MedicalCentre.ViewModels.AdminWindowPagesViewModels;

public class PatientsViewModel
{
    public ObservableCollection<Patient> Patients { get; set; } = new();
    public ICommand? SearchCommand { get; set; }
    public ICommand? OpenRegistrationCommand { get; set; }
    public ICommand? OpenNewsCommand { get; set; }

    private PatientsPage page;
    private IServiceProvider serviceProvider;
    public PatientsViewModel(PatientsPage page, IServiceProvider serviceProvider)
    {
        this.page = page;
        this.serviceProvider = serviceProvider;

        SearchCommand = new RelayCommandAsync(SearchItems);
        OpenRegistrationCommand = new RelayCommand(OpenRegistration);
        OpenNewsCommand = new RelayCommand(OpenNews);

        page.Search.TextChanged += OnTextChanged;

        SearchItems();
    }
    
    private void OpenRegistration()
    {
        PatientRegistration patientRegister = new();
        patientRegister.Show();
    }

    private async Task SearchItems()
    {
        IRepository<Patient> patientsDb = serviceProvider.GetRequiredService<IRepository<Patient>>();
        Patients = new ObservableCollection<Patient>(await Task.Run( () => patientsDb.GetTableAsync()));
        Patients = new ObservableCollection<Patient>(SearchFilterService<Patient>.GetFilteredList(Patients.ToList(), page.Search.Text));

        page.PatientsCards.Children.Clear();

        foreach (var patient in Patients)
        {
            page.PatientsCards.Children.Insert(0, new PatientCard(patient));
        }
    }

    private void OnTextChanged(object sender, TextChangedEventArgs args) => SearchItems();

    private void OpenNews() => OpenBrowserService.OpenPageInBrowser(Properties.Settings.Default.OpenHealthNews);
}