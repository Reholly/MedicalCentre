using MedicalCentre.Models;
using MedicalCentre.Services;
using MedicalCentre.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MedicalCentre.ViewModels;

public class MainViewModel
{
    public ICommand LoginCommand { get; set; }
    public ICommand CloseCommand { get; set; }

    private MainWindow window;
    private AuthentificationService authentificationService;
    private IServiceProvider serviceProvider;

    public MainViewModel(MainWindow window, IServiceProvider serviceProvider)
    {
        this.window = window;
        this.serviceProvider = serviceProvider;
        this.authentificationService = serviceProvider.GetRequiredService<AuthentificationService>();
        LoginCommand = new RelayCommandAsync(Login);
        CloseCommand = new RelayCommand(Close);
    }

    private async Task Login()
    {
        string login = window.Login.Text;
        string password = window.Password.Password;
        Account account = await Task.Run(() => Authentificate(login, password));
        if (account != null)
        {
            await WindowOpenerByRoleService.OpenWindowByRole(account, serviceProvider);
            Close();
        }
    }
    private async Task<Account> Authentificate(string login, string password)
    {
        Account account = await authentificationService.LogInAsync(login, password);
           
        return account;      
    }
    private void Close() => window.Close();
}
