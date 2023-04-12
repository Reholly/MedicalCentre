using MedicalCentre.Models;
using MedicalCentre.Pages.OperatorPages;
using MedicalCentre.Services;
using MedicalCentre.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace MedicalCentre.Views;

public partial class OperatorWindow : Window
{
    public OperatorWindow(Account account, IServiceCollection services)
    {
        InitializeComponent();

        EmployeeNameBinderService.BindName(account, RoleName, EmployeeName);

        MainFrame.Content = new MainPage();
        DataContext = new OperatorWindowViewModel(this, account, services);
    }
}