using MedicalCentre.ViewModels.AdminWindowPagesViewModels;
using System;
using System.Windows.Controls;

namespace MedicalCentre.Pages.AdminWindowPages;

public partial class EmployeesManagementPage : Page
{
    public EmployeesManagementPage(IServiceProvider serviceProvider)
    {
        InitializeComponent();
        DataContext = new EmployeeManagementViewModel(this, serviceProvider);
    }
}
