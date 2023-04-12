using MedicalCentre.Models;
using MedicalCentre.Pages.DoctorWindowPages;
using MedicalCentre.Services;
using MedicalCentre.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace MedicalCentre.Views;

public partial class DoctorWindow : Window
{
    public DoctorWindow(Account account, IServiceCollection services)
    {
        InitializeComponent();

        EmployeeNameBinderService.BindName(account, RoleName, EmployeeName);

        MainFrame.Content = new DoctorMainPage(this, account, services);
        DataContext = new DoctorViewModel(this, account, services);
    }
}