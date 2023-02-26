using MedicalCentre.DatabaseLayer;
using MedicalCentre.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;
using MedicalCentre.Pages.SystemAdminPages;

namespace MedicalCentre.ViewModels.SystemAdminViewModels
{
    public class LogsPanelViewModel
    {
        public ObservableCollection<Log> Logs { get; set; } = new();
        public ICommand? ShowTableCommand { get; set; }

        private LogsPanel page;
        public LogsPanelViewModel(LogsPanel page)
        {
            this.page = page;
            ShowTableCommand = new RelayCommand(ShowTable);
        }

        private async void ShowTable()
        {
            Database<Log> logDb = new Database<Log>();  
            var logs = await logDb.GetTableAsync();
            Logs = new ObservableCollection<Log>(logs);

            page.LogsGrid.ItemsSource = Logs;
            page.LogsGrid.Visibility = Visibility.Visible;
        }          
    }
}