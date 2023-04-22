using MedicalCentre.Models;
using MedicalCentre.Pages.AdminWindowPages;
using MedicalCentre.Services;
using MedicalCentre.ViewModels;
using System;
using System.Windows;

namespace MedicalCentre.Views;

public partial class AdminWindow : Window
{
    public AdminWindow(Account account, IServiceProvider serviceProvider)
    {
        InitializeComponent();

        EmployeeNameBinderService.BindName(account, RoleName, EmployeeName);

        MainFrame.Content = new MainPage(serviceProvider);
        DataContext = new AdminViewModel(this, account, serviceProvider);
    }
}