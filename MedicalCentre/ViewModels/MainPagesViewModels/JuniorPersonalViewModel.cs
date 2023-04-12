using MedicalCentre.Models;
using MedicalCentre.Pages.GeneralPages;
using MedicalCentre.Services;
using MedicalCentre.Views;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MedicalCentre.ViewModels;

public class JuniorPersonalViewModel
{
    public ICommand ShowStorageItemsCommand { get; set; }
    public ICommand LogoutCommand { get; set; }

    private JuniorPersonalWindow window;
    private Account account;
    private AuthentificationService authentificationService;
    private IServiceCollection services;

    public JuniorPersonalViewModel(JuniorPersonalWindow window, Account account, IServiceCollection services)
    {
        this.window = window;
        this.account = account;
        this.authentificationService = services.BuildServiceProvider().GetRequiredService<AuthentificationService>();
        this.services = services;
        ShowStorageItemsCommand = new RelayCommand(ShowStorageItems);
        LogoutCommand = new RelayCommandAsync(Close);
    }

    private void ShowStorageItems() => window.frame.Content = new StoragePage(services);

    private async Task Close()
    {
        await authentificationService.LogOutAsync(account);
        window.Close();
    }
}