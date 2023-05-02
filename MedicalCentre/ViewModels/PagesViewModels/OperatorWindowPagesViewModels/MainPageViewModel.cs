using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using MedicalCentre.Authentification;
using MedicalCentre.Forms;
using MedicalCentre.Models;
using MedicalCentre.Pages.OperatorPages;
using MedicalCentre.Services;
using System;
using System.Linq;
using MedicalCentre.DatabaseLayer;
using MedicalCentre.ViewModels.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace MedicalCentre.ViewModels.PagesViewModels.OperatorWindowPagesViewModels;

public class MainPageViewModel
{
    public ICommand OpenNewsCommand { get; set; }
    public ICommand OpenNewFeaturesCommand { get; set; }
    public ICommand WriteCommand { get; set; }
    public ICommand CreateCommand { get; set; }
    
    private readonly IServiceProvider serviceProvider;
    public MainPageViewModel(IServiceProvider serviceProvider)
    {
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
        var doctorsList = await Task.Run(InitDoctors);
        var window = new AppointmentCreatingForm(doctorsList, serviceProvider);
        window.Show();
    }

    private void Write()
    {
        WriteAppointment window = new WriteAppointment(serviceProvider);
        window.Show();
    }

    private async Task<List<Employee>> InitDoctors()
    {
        var accounts = await Task.Run(() => serviceProvider.GetRequiredService<IRepository<Account>>().GetTableAsync());
        var doctorsList = new List<Employee>();
        foreach (var account in accounts.Where(account => account.Role == Roles.Doctor))
        {
            var doctor = await Task.Run(() => serviceProvider.GetRequiredService<IRepository<Employee>>().GetItemByIdAsync(account.EmployeeAccountId));
            doctorsList.Add(doctor);
        }

        return doctorsList;
    }
}