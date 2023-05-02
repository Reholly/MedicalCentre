using System;
using System.Threading.Tasks;
using System.Windows.Input;
using MedicalCentre.Models;
using MedicalCentre.Pages.DoctorWindowPages;
using MedicalCentre.Services;
using MedicalCentre.ViewModels.Commands;
using MedicalCentre.Views;
using Microsoft.Extensions.DependencyInjection;

namespace MedicalCentre.ViewModels.MainPagesViewModels;

public class DoctorWindowViewModel
{
    public ICommand WindowClosingCommand { get; set; }
    public ICommand OpeningMainPageCommand { get; set; }

    private readonly DoctorWindow window;
    private readonly Account account;
    private readonly AuthentificationService authentificationService;
    private readonly IServiceProvider serviceProvider;

    public DoctorWindowViewModel(DoctorWindow window, Account account, IServiceProvider serviceProvider)
    {
        this.window = window;
        this.account = account;
        this.serviceProvider = serviceProvider;
        authentificationService = serviceProvider.GetRequiredService<AuthentificationService>();
        WindowClosingCommand = new RelayCommandAsync(Close);
        OpeningMainPageCommand = new RelayCommand(OpenMainPage);
    }

    private async Task Close()
    {      
        await Task.Run(() => authentificationService.LogOutAsync(account));
        window.Close();
    }

    private void OpenMainPage() => window.MainFrame.Content = new DoctorMainPage(window, account, serviceProvider);
}