using MedicalCentre.ViewModels.AdminWindowPagesViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Controls;

namespace MedicalCentre.Pages.AdminWindowPages;

public partial class CentreSettingsPage : Page
{
    public CentreSettingsPage(IServiceCollection services)
    {
        InitializeComponent();
        DataContext = new CentreSettingsViewModel(this, services);
    }
}
