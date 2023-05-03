using System;
using System.Windows.Controls;
using MedicalCentre.ViewModels.PagesViewModels.AdminWindowPagesViewModels;

namespace MedicalCentre.Pages.AdminWindowPages;

public partial class PatientsPage : Page
{
    public PatientsPage(IServiceProvider services)
    {
        InitializeComponent();
        DataContext = new PatientsPageViewModel(this, services);
    }
}
