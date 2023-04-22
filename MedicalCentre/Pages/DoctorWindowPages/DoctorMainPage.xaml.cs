using MedicalCentre.Models;
using MedicalCentre.ViewModels.DoctorWindowPagesViewModels;
using MedicalCentre.Views;
using System;
using System.Windows.Controls;

namespace MedicalCentre.Pages.DoctorWindowPages;

public partial class DoctorMainPage : Page
{
    public DoctorMainPage(DoctorWindow window, Account account, IServiceProvider serviceProvider)
    {
        InitializeComponent();
        DataContext = new DoctorMainPageViewModel(this, window, account, serviceProvider);
    }
}