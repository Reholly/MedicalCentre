using MedicalCentre.DatabaseLayer;
using MedicalCentre.Models;
using MedicalCentre.Pages.AdminWindowPages;
using MedicalCentre.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MedicalCentre.ViewModels.AdminWindowPagesViewModels
{
    internal class CentreSettingsViewModel
    {
        public ObservableCollection<Log> Logs { get; set; } = new();
        public ICommand? OpenDbCommand { get; set; }
        public ICommand? OpenHostCommand { get; set; }


        private CentreSettingsPage settingsPage;

        public CentreSettingsViewModel(CentreSettingsPage page)
        {
            settingsPage = page;

            OpenDbCommand = new RelayCommand(OpenDatabaseMenu);
            OpenHostCommand = new RelayCommand(OpenHostSite);

            Update();
        }

        private async Task Update()
        {
            var logDb = new ContextRepository<Log>();
            Logs = new ObservableCollection<Log>(await logDb.GetTableAsync());

            settingsPage.Logs.ItemsSource = Logs;
            settingsPage.Logs.Visibility = Visibility.Visible;
        }

        public void OpenDatabaseMenu()
        {
            OpenBrowserService.OpenPageInBrowser(Properties.Settings.Default.PhpMyAdmin);
        }

        public void OpenHostSite()
        {
            OpenBrowserService.OpenPageInBrowser(Properties.Settings.Default.Host);
        }
    }
}
