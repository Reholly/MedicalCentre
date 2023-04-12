using MedicalCentre.ViewModels.AdminWindowPagesViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Controls;

namespace MedicalCentre.Pages.AdminWindowPages;

public partial class PatientsPage : Page
{
    public PatientsPage(IServiceCollection services)
    {
        InitializeComponent();
        DataContext = new PatientsViewModel(this, services);
    }
}
