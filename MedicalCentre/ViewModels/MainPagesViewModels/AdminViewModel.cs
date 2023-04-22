using MedicalCentre.Models;
using MedicalCentre.Pages.AdminWindowPages;
using MedicalCentre.Services;
using MedicalCentre.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
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
    private IServiceProvider serviceProvider;

    public AdminViewModel(AdminWindow window, Account account, IServiceProvider serviceProvider)
    {
        adminWindow = window;
        currentAccount = account;
        this.serviceProvider = serviceProvider;

        CloseCommand = new RelayCommandAsync(Close);
        OpenEmployeesCommand = new RelayCommand(OpenEmployeesPage);
        OpenPatientsCommand = new RelayCommand(OpenPatientsPage);
        OpenMainCommand = new RelayCommand(OpenMainPage);
        OpenCentreSettings = new RelayCommand(OpentSettingsPage);

        this.authentificationService = serviceProvider.GetRequiredService<AuthentificationService>();
    }

    private async Task Close()
    {       
        await authentificationService.LogOutAsync(currentAccount);
        adminWindow.Close();
    }  

    private void OpenEmployeesPage()
    {
        adminWindow.MainFrame.Content = new EmployeesManagementPage(serviceProvider);
    }

    private void OpenPatientsPage()
    {
        adminWindow.MainFrame.Content = new PatientsPage(serviceProvider);
    }

    private void OpenMainPage()
    {
        adminWindow.MainFrame.Content = new MainPage(serviceProvider);
    }

    private void OpentSettingsPage()
    {
        adminWindow.MainFrame.Content = new CentreSettingsPage(serviceProvider);
    }
}
