using System;
using System.Threading.Tasks;
using System.Windows.Input;
using MedicalCentre.Models;
using MedicalCentre.Services;
using MedicalCentre.ViewModels.Commands;
using MedicalCentre.Views;
using Microsoft.Extensions.DependencyInjection;

namespace MedicalCentre.ViewModels.MainPagesViewModels;

public class MainViewModel
{
    public ICommand LoginCommand { get; set; }
    public ICommand CloseCommand { get; set; }

    private readonly MainWindow window;
    private readonly AuthentificationService authentificationService;
    private readonly IServiceProvider serviceProvider;

    public MainViewModel(MainWindow window, IServiceProvider serviceProvider)
    {
        this.window = window;
        this.serviceProvider = serviceProvider;
        authentificationService = serviceProvider.GetRequiredService<AuthentificationService>();
        LoginCommand = new RelayCommandAsync(Login);
        CloseCommand = new RelayCommand(Close);
    }

    private async Task Login()
    {
        var login = window.Login.Text;
        var password = window.Password.Password;
        var account = await Task.Run(() => Authentificate(login, password));
        await WindowOpenerByRoleService.OpenWindowByRole(account, serviceProvider);
        Close();
    }
    private async Task<Account> Authentificate(string login, string password)
    {
        var account = await Task.Run(() => authentificationService.LogInAsync(login, password));
        return account;      
    }
    private void Close() => window.Close();
}
