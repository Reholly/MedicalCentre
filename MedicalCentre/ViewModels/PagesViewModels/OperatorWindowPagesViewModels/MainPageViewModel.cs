using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using MedicalCentre.Authentification;
using MedicalCentre.DatabaseLayer;
using MedicalCentre.Forms;
using MedicalCentre.Migrations;
using MedicalCentre.Models;
using MedicalCentre.Pages.OperatorPages;
using MedicalCentre.Services;
using System;
using System.Windows.Input;

namespace MedicalCentre.ViewModels.PagesViewModels.OperatorWindowPagesViewModels;

public class MainPageViewModel
{
    public ICommand OpenNewsCommand { get; set; }
    public ICommand OpenNewFeaturesCommand { get; set; }
    public ICommand WriteCommand { get; set; }
    public ICommand CreateCommand { get; set; }

    private MainPage currentPage;
    private readonly IServiceProvider serviceProvider;
    public MainPageViewModel(MainPage page, IServiceProvider serviceProvider)
    {
        currentPage = page;
        this.serviceProvider = serviceProvider;

        OpenNewsCommand = new RelayCommand(OpenNews);
        OpenNewFeaturesCommand = new RelayCommand(OpenNewFeatures);
        CreateCommand = new RelayCommandAsync(Create);
        WriteCommand = new RelayCommand(Write);
    }

    private void OpenNews() => OpenBrowserService.OpenPageInBrowser(Properties.Settings.Default.OpenInvalidSite);
    
    private void OpenNewFeatures() => OpenBrowserService.OpenPageInBrowser(Properties.Settings.Default.NewFeatures);
    

    private async Task Create()
    {
        CreateAppointment window = new CreateAppointment(serviceProvider);
        window.Show();
    }

    private void Write()
    {
        WriteAppointment window = new WriteAppointment(serviceProvider);
        window.Show();
    }

    private async Task<List<Employee>> InitDoctors()
    {
        var accounts = await Task.Run(() => accDb.GetTableAsync());
        var doctorsList = new List<Employee>();
        foreach (var account in accounts.Where(account => account.Role == Roles.Doctor))
        {
            var doctor = await Task.Run(() => doctorDb.GetItemByIdAsync(account.EmployeeAccountId));
            doctorsList.Add(doctor);
        }

        return doctorsList;
    }
}