using MedicalCentre.Models;
using MedicalCentre.Pages.DoctorWindowPages;
using MedicalCentre.Services;
using MedicalCentre.ViewModels;
using System;
using System.Windows;

namespace MedicalCentre.Views;

public partial class DoctorWindow : Window
{
    public DoctorWindow(Account account, IServiceProvider services)
    {
        InitializeComponent();

        EmployeeNameBinderService.BindName(account, RoleName, EmployeeName);

        MainFrame.Content = new DoctorMainPage(this, account, services);
        DataContext = new DoctorViewModel(this, account, services);
    }
}