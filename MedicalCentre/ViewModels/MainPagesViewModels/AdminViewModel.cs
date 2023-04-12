using MedicalCentre.Models;
using MedicalCentre.Pages.AdminWindowPages;
using MedicalCentre.Services;
using MedicalCentre.Views;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MedicalCentre.ViewModels;

public class AdminViewModel
{   
    public ICommand? CloseCommand { get; set; }
    public ICommand? OpenEmployeesCommand { get; set; }
    public ICommand? OpenPatientsCommand { get; set; }
    public ICommand? OpenMainCommand { get; set; }
    public ICommand? OpenCentreSettings { get; set; }

    private AdminWindow adminWindow;
    private Account currentAccount;
    private AuthentificationService authentificationService;
    private IServiceCollection services;

    public AdminViewModel(AdminWindow window, Account account, IServiceCollection services)
    {
        adminWindow = window;
        currentAccount = account;
        this.services = services;

        CloseCommand = new RelayCommandAsync(Close);
        OpenEmployeesCommand = new RelayCommand(OpenEmployeesPage);
        OpenPatientsCommand = new RelayCommand(OpenPatientsPage);
        OpenMainCommand = new RelayCommand(OpenMainPage);
        OpenCentreSettings = new RelayCommand(OpentSettingsPage);

        this.authentificationService = services.BuildServiceProvider().GetRequiredService<AuthentificationService>();
    }

    private async Task Close()
    {       
        await authentificationService.LogOutAsync(currentAccount);
        adminWindow.Close();
    }  

    private void OpenEmployeesPage()
    {
        adminWindow.MainFrame.Content = new EmployeesManagementPage(services);
    }

    private void OpenPatientsPage()
    {
        adminWindow.MainFrame.Content = new PatientsPage(services);
    }

    private void OpenMainPage()
    {
        adminWindow.MainFrame.Content = new MainPage(services);
    }

    private void OpentSettingsPage()
    {
        adminWindow.MainFrame.Content = new CentreSettingsPage(services);
    }
}
