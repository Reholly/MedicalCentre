using System;
using System.Threading.Tasks;
using System.Windows.Input;
using MedicalCentre.Models;
using MedicalCentre.Pages.AdminWindowPages;
using MedicalCentre.Services;
using MedicalCentre.ViewModels.Commands;
using MedicalCentre.Views;
using Microsoft.Extensions.DependencyInjection;

namespace MedicalCentre.ViewModels.MainPagesViewModels;

public class AdminWindowViewModel
{   
    public ICommand CloseCommand { get; set; }
    public ICommand OpenEmployeesCommand { get; set; }
    public ICommand OpenPatientsCommand { get; set; }
    public ICommand OpenMainCommand { get; set; }
    public ICommand OpenCentreSettings { get; set; }

    private readonly AdminWindow adminWindow;
    private readonly Account currentAccount;
    private readonly AuthentificationService authentificationService;
    private readonly IServiceProvider serviceProvider;

    public AdminWindowViewModel(AdminWindow window, Account account, IServiceProvider serviceProvider)
    {
        adminWindow = window;
        currentAccount = account;
        this.serviceProvider = serviceProvider;

        CloseCommand = new RelayCommandAsync(Close);
        OpenEmployeesCommand = new RelayCommand(OpenEmployeesPage);
        OpenPatientsCommand = new RelayCommand(OpenPatientsPage);
        OpenMainCommand = new RelayCommand(OpenMainPage);
        OpenCentreSettings = new RelayCommand(OpenSettingsPage);

        authentificationService = serviceProvider.GetRequiredService<AuthentificationService>();
    }

    private async Task Close()
    {       
        await Task.Run(() => authentificationService.LogOutAsync(currentAccount));
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

    private void OpenSettingsPage()
    {
        adminWindow.MainFrame.Content = new CentreSettingsPage(serviceProvider);
    }
}
