using MedicalCentre.ViewModels.AdminWindowPagesViewModels;
using System;
using System.Windows.Controls;

namespace MedicalCentre.Pages.AdminWindowPages;

public partial class PatientsPage : Page
{
    public PatientsPage(IServiceProvider services)
    {
        InitializeComponent();
        DataContext = new PatientsViewModel(this, services);
    }
}
