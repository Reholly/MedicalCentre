using MedicalCentre.ViewModels.AdminWindowPagesViewModels;
using System;
using System.Windows.Controls;

namespace MedicalCentre.Pages.AdminWindowPages;

public partial class CentreSettingsPage : Page
{
    public CentreSettingsPage(IServiceProvider serviceProvider)
    {
        InitializeComponent();
        DataContext = new CentreSettingsViewModel(this, serviceProvider);
    }
}
