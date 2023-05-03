using MedicalCentre.Models;
using MedicalCentre.Pages.OperatorPages;
using MedicalCentre.Services;
using MedicalCentre.ViewModels;
using System;
using System.Windows;
using MedicalCentre.ViewModels.MainPagesViewModels;

namespace MedicalCentre.Views;

public partial class OperatorWindow : Window
{
    public OperatorWindow(Account account, IServiceProvider serviceProvider)
    {
        InitializeComponent();

        EmployeeNameBinderService.BindName(account, RoleName, EmployeeName);

        MainFrame.Content = new MainPage(serviceProvider);
        DataContext = new OperatorWindowViewModel(this, account, serviceProvider);
    }
}