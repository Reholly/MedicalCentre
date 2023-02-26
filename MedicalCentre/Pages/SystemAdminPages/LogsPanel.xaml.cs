using MedicalCentre.ViewModels.SystemAdminViewModels;
using System.Windows.Controls;


namespace MedicalCentre.Pages.SystemAdminPages
{
    /// <summary>
    /// Логика взаимодействия для LogsPanel.xaml
    /// </summary>
    public partial class LogsPanel : Page
    {
        public LogsPanel()
        {
            InitializeComponent();
            DataContext = new LogsPanelViewModel(this);
        }
    }
}
