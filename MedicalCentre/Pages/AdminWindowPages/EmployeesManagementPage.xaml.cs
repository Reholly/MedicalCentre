using MedicalCentre.Services;
using MedicalCentre.ViewModels.AdminWindowPagesViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Controls;

namespace MedicalCentre.Pages.AdminWindowPages;

public partial class EmployeesManagementPage : Page
{
    public EmployeesManagementPage(IServiceCollection services)
    {
        InitializeComponent();
        DataContext = new EmployeeManagementViewModel(this, services);
    }
}
