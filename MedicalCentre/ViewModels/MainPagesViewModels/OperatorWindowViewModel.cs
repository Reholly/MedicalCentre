using MedicalCentre.Models;
using MedicalCentre.Pages.AdminWindowPages;
using MedicalCentre.Services;
using MedicalCentre.Views;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MedicalCentre.ViewModels;

public class OperatorWindowViewModel
{
    public ICommand PatientsPageOpeningCommand { get; set; }
    public ICommand AppointmentsManagementPageOpeningCommand { get; set; }
    public ICommand WindowClosingCommand { get; set; }

    private OperatorWindow window;
    private Account currentAccount;
    private AuthentificationService authentificationService;
    private IServiceCollection services;

    public OperatorWindowViewModel(OperatorWindow window, Account account, IServiceCollection services)
    {
        this.window = window;
        this.currentAccount = account;
        this.services = services;
        this.authentificationService = services.BuildServiceProvider().GetRequiredService<AuthentificationService>();

        PatientsPageOpeningCommand = new RelayCommand(OpenPatientsPage);
        AppointmentsManagementPageOpeningCommand = new RelayCommand(OpenAppointmentsManagementPage);
        WindowClosingCommand = new RelayCommandAsync(Close);
    }

    private void OpenPatientsPage() => window.MainFrame.Content = new PatientsPage(services);
    private void OpenAppointmentsManagementPage() => window.MainFrame.Content = new MedicalCentre.Pages.OperatorPages.MainPage();
    private async Task Close()
    {
        await authentificationService.LogOutAsync(currentAccount);
        window.Close();
    }
}