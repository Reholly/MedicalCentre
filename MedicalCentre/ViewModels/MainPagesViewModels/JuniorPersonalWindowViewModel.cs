using System;
using System.Threading.Tasks;
using System.Windows.Input;
using MedicalCentre.Models;
using MedicalCentre.Pages.JuniorPersonalWindowPages;
using MedicalCentre.Services;
using MedicalCentre.ViewModels.Commands;
using MedicalCentre.Views;
using Microsoft.Extensions.DependencyInjection;

namespace MedicalCentre.ViewModels.MainPagesViewModels;

public class JuniorPersonalWindowViewModel
{
    public ICommand ShowStorageItemsCommand { get; set; }
    public ICommand LogoutCommand { get; set; }

    private readonly JuniorPersonalWindow window;
    private readonly Account account;
    private readonly AuthentificationService authentificationService;
    private readonly IServiceProvider serviceProvider;

    public JuniorPersonalWindowViewModel(JuniorPersonalWindow window, Account account, IServiceProvider serviceProvider)
    {
        this.window = window;
        this.account = account;
        authentificationService = serviceProvider.GetRequiredService<AuthentificationService>();
        this.serviceProvider = serviceProvider;
        ShowStorageItemsCommand = new RelayCommand(ShowStorageItems);
        LogoutCommand = new RelayCommandAsync(Close);
    }

    private void ShowStorageItems() => window.frame.Content = new StoragePage(serviceProvider);

    private async Task Close()
    {
        await Task.Run(() => authentificationService.LogOutAsync(account));
        window.Close();
    }
}