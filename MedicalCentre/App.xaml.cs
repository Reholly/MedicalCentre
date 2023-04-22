using MedicalCentre.Authentification;
using MedicalCentre.DatabaseLayer;
using MedicalCentre.Services;
using MedicalCentre.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace MedicalCentre;

public partial class App : Application
{
    private IServiceProvider serviceProvider = null!;
    private IServiceCollection services = null!;

    protected override void OnStartup(StartupEventArgs e)
    {
        AccountPrincipal employeePrincipal = new AccountPrincipal();
        AppDomain.CurrentDomain.SetThreadPrincipal(employeePrincipal);

        services = new ServiceCollection();   
        ConfigureServices(services);

        serviceProvider = services.BuildServiceProvider();

        base.OnStartup(e);
    }

    private void ConfigureServices(IServiceCollection services)
    {
        services.AddTransient(typeof(IRepository<>), typeof(ContextRepository<>));
        services.AddTransient<IAuthentification,DefaultAuthentification>();
        services.AddSingleton<IErrorHandler, WPFErrorHandler>();
        services.AddTransient<AuthentificationService>();
    }

    private void OnStartup(object sender, StartupEventArgs e)
    {
        var mainWindow = new MainWindow(serviceProvider);
        mainWindow.Show();
    }
}