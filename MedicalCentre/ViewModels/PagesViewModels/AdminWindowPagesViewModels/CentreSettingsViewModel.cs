using MedicalCentre.DatabaseLayer;
using MedicalCentre.Models;
using MedicalCentre.Pages.AdminWindowPages;
using MedicalCentre.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using MedicalCentre.ViewModels.Commands;

namespace MedicalCentre.ViewModels.AdminWindowPagesViewModels;

public class CentreSettingsViewModel
{
    public ObservableCollection<Log> Logs { get; set; } = new ObservableCollection<Log>();
    public ICommand? OpenDbCommand { get; set; }
    public ICommand? OpenHostCommand { get; set; }

    private CentreSettingsPage settingsPage;
    private IServiceProvider serviceProvider;

    public CentreSettingsViewModel(CentreSettingsPage page, IServiceProvider services)
    {
        settingsPage = page;
        this.serviceProvider = services;

        OpenDbCommand = new RelayCommand(OpenDatabaseMenu);
        OpenHostCommand = new RelayCommand(OpenHostSite);

        Update();
    }

    private async Task Update()
    {
        var logDb = serviceProvider.GetRequiredService<IRepository<Log>>();
        Logs = new ObservableCollection<Log>(await Task.Run(logDb.GetTableAsync));

        settingsPage.Logs.ItemsSource = Logs;
        settingsPage.Logs.Visibility = Visibility.Visible;
    }

    private void OpenDatabaseMenu() => OpenBrowserService.OpenPageInBrowser(Properties.Settings.Default.PhpMyAdmin);
        
    private void OpenHostSite() => OpenBrowserService.OpenPageInBrowser(Properties.Settings.Default.Host);   
}