using System;
using System.Windows.Controls;
using MedicalCentre.ViewModels.PagesViewModels.AdminWindowPagesViewModels;

namespace MedicalCentre.Pages.AdminWindowPages;

public partial class CentreSettingsPage : Page
{
    public CentreSettingsPage(IServiceProvider serviceProvider)
    {
        InitializeComponent();
        DataContext = new CentreSettingsViewModel(this, serviceProvider);
    }
}
