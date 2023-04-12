using MedicalCentre.DatabaseLayer;
using MedicalCentre.Models;
using MedicalCentre.Pages.AdminWindowPages;
using MedicalCentre.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MedicalCentre.ViewModels.AdminWindowPagesViewModels;

public class CentreSettingsViewModel
{
    public ObservableCollection<Log> Logs { get; set; } = new ObservableCollection<Log>();
    public ICommand? OpenDbCommand { get; set; }
    public ICommand? OpenHostCommand { get; set; }

    private CentreSettingsPage settingsPage;
    private IServiceCollection services;

    public CentreSettingsViewModel(CentreSettingsPage page, IServiceCollection services)
    {
        settingsPage = page;
        this.services = services;

        OpenDbCommand = new RelayCommand(OpenDatabaseMenu);
        OpenHostCommand = new RelayCommand(OpenHostSite);

        Update();
    }

    private async Task Update()
    {
        var logDb = services.BuildServiceProvider().GetRequiredService<IRepository<Log>>();
        Logs = new ObservableCollection<Log>(await Task.Run(logDb.GetTableAsync));

        settingsPage.Logs.ItemsSource = Logs;
        settingsPage.Logs.Visibility = Visibility.Visible;
    }

    private void OpenDatabaseMenu() => OpenBrowserService.OpenPageInBrowser(Properties.Settings.Default.PhpMyAdmin);
        
    private void OpenHostSite() => OpenBrowserService.OpenPageInBrowser(Properties.Settings.Default.Host);   
}