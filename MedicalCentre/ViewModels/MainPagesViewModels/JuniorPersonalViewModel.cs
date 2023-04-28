using MedicalCentre.Models;
using MedicalCentre.Pages.GeneralPages;
using MedicalCentre.Services;
using MedicalCentre.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using MedicalCentre.ViewModels.Commands;

namespace MedicalCentre.ViewModels;

public class JuniorPersonalViewModel
{
    public ICommand ShowStorageItemsCommand { get; set; }
    public ICommand LogoutCommand { get; set; }

    private JuniorPersonalWindow window;
    private Account account;
    private AuthentificationService authentificationService;
    private IServiceProvider serviceProvider;

    public JuniorPersonalViewModel(JuniorPersonalWindow window, Account account, IServiceProvider serviceProvider)
    {
        this.window = window;
        this.account = account;
        this.authentificationService = serviceProvider.GetRequiredService<AuthentificationService>();
        this.serviceProvider = serviceProvider;
        ShowStorageItemsCommand = new RelayCommand(ShowStorageItems);
        LogoutCommand = new RelayCommandAsync(Close);
    }

    private void ShowStorageItems() => window.frame.Content = new StoragePage(serviceProvider);

    private async Task Close()
    {
        await authentificationService.LogOutAsync(account);
        window.Close();
    }
}