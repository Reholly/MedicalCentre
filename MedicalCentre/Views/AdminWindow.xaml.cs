using MedicalCentre.Models;
using MedicalCentre.Pages.AdminWindowPages;
using MedicalCentre.Services;
using MedicalCentre.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace MedicalCentre.Views;

public partial class AdminWindow : Window
{
    public AdminWindow(Account account, IServiceCollection services)
    {
        InitializeComponent();

        EmployeeNameBinderService.BindName(account, RoleName, EmployeeName);

        MainFrame.Content = new MainPage(services);
        DataContext = new AdminViewModel(this, account, services);
    }
}