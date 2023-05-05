using MedicalCentre.Models;
using System;
using System.Windows;
using MedicalCentre.ViewModels.MainPagesViewModels;
using MedicalCentre.Services;

namespace MedicalCentre.Views;

public partial class JuniorPersonalWindow : Window
{
    public JuniorPersonalWindow(Account account, IServiceProvider serviceProvider)
    {
        InitializeComponent();

        EmployeeNameBinderService.BindName(account, RoleName, EmployeeName);

        DataContext = new JuniorPersonalWindowViewModel(this, account, serviceProvider);
    }
}