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
using MedicalCentre.ViewModels.Commands;

namespace MedicalCentre.ViewModels.PagesViewModels.OperatorWindowPagesViewModels;

public class MainPageViewModel
{
    public ICommand OpenNewsCommand { get; set; }
    public ICommand OpenNewFeaturesCommand { get; set; }
    public ICommand WriteCommand { get; set; }
    public ICommand CreateCommand { get; set; }

    private readonly MainPage currentPage;
    private readonly ContextRepository<Account> accDb = new();
    private readonly ContextRepository<Employee> doctorDb = new();

    public MainPageViewModel(MainPage page)
    {
        this.currentPage = page;
        OpenNewsCommand = new RelayCommand(OpenNews);
        OpenNewFeaturesCommand = new RelayCommand(OpenNewFeatures);
        CreateCommand = new RelayCommandAsync(Create);
        WriteCommand = new RelayCommand(Write);
    }

    private void OpenNews() => OpenBrowserService.OpenPageInBrowser(Properties.Settings.Default.OpenInvalidSite);
    
    private void OpenNewFeatures() => OpenBrowserService.OpenPageInBrowser(Properties.Settings.Default.NewFeatures);
    

    private async Task Create()
    {
        var doctors = await Task.Run(InitDoctors);
        var window = new AppointmentCreatingForm(doctors);
        window.Show();
    }

    private void Write()
    {
        WriteAppointment window = new WriteAppointment();
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