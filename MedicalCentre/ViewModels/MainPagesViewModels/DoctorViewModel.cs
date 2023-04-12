using MedicalCentre.Models;
using MedicalCentre.Pages.DoctorWindowPages;
using MedicalCentre.Services;
using MedicalCentre.Views;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MedicalCentre.ViewModels;

public class DoctorViewModel
{
    public ICommand WindowClosingCommand { get; set; }
    public ICommand OpeningMainPageCommand { get; set; }

    private DoctorWindow window;
    private Account account;
    private AuthentificationService authentificationService;
    private IServiceCollection services;

    public DoctorViewModel(DoctorWindow window, Account account, IServiceCollection services)
    {
        this.window = window;
        this.account = account;
        this.services = services;
        this.authentificationService = services.BuildServiceProvider().GetRequiredService<AuthentificationService>();
        WindowClosingCommand = new RelayCommandAsync(Close);
        OpeningMainPageCommand = new RelayCommand(OpenMainPage);
    }

    private async Task Close()
    {      
        await authentificationService.LogOutAsync(account);
        window.Close();
    }

    private void OpenMainPage() => window.MainFrame.Content = new DoctorMainPage(window, account, services);
}