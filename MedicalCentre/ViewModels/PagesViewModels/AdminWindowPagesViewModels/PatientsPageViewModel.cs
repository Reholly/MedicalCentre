using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using MedicalCentre.DatabaseLayer;
using MedicalCentre.Forms;
using MedicalCentre.Models;
using MedicalCentre.Pages.AdminWindowPages;
using MedicalCentre.Services;
using MedicalCentre.UserControls;
using MedicalCentre.ViewModels.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace MedicalCentre.ViewModels.PagesViewModels.AdminWindowPagesViewModels;

public class PatientsPageViewModel
{
    private ObservableCollection<Patient> Patients { get; set; } = new();
    public ICommand SearchCommand { get; set; }
    public ICommand OpenRegistrationCommand { get; set; }
    public ICommand OpenNewsCommand { get; set; }

    private readonly PatientsPage page;
    private readonly IServiceProvider serviceProvider;
    public PatientsPageViewModel(PatientsPage page, IServiceProvider serviceProvider)
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
        var patientRegister = new PatientRegistrationFrom();
        patientRegister.Show();
    }

    private async Task SearchItems()
    {
        var patientsDb = serviceProvider.GetRequiredService<IRepository<Patient>>();
        Patients = new ObservableCollection<Patient>(await Task.Run( () => patientsDb.GetTableAsync()));
        Patients = new ObservableCollection<Patient>(SearchFilterService<Patient>.GetFilteredList(Patients.ToList(), page.Search.Text));

        page.PatientsCards.Children.Clear();

        foreach (var patient in Patients)
        {
            page.PatientsCards.Children.Insert(0, new PatientCard(patient));
        }
    }

    private void OnTextChanged(object sender, TextChangedEventArgs args) => Task.Run(SearchItems);

    private void OpenNews() => OpenBrowserService.OpenPageInBrowser(Properties.Settings.Default.OpenHealthNews);
}