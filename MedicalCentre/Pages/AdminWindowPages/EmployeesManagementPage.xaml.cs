using System;
using System.Windows.Controls;
using MedicalCentre.ViewModels.PagesViewModels.AdminWindowPagesViewModels;

namespace MedicalCentre.Pages.AdminWindowPages;

public partial class EmployeesManagementPage : Page
{
    public EmployeesManagementPage(IServiceProvider serviceProvider)
    {
        InitializeComponent();
        DataContext = new EmployeeManagementPageViewModel(this, serviceProvider);
    }
}
