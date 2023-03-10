using MedicalCentre.ViewModels.AdminWindowPagesViewModels;
using System.Windows.Controls;

namespace MedicalCentre.Pages.AdminWindowPages
{
    public partial class CentreSettingsPage : Page
    {
        public CentreSettingsPage()
        {
            InitializeComponent();
            DataContext = new CentreSettingsViewModel(this);
        }
    }
}
