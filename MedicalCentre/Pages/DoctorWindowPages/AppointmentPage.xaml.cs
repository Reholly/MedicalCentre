using MedicalCentre.Models;
using MedicalCentre.Views;
using System;
using System.Windows.Controls;
using MedicalCentre.ViewModels.PagesViewModels.DoctorWindowPagesViewModels;

namespace MedicalCentre.Pages.DoctorWindowPages;

public partial class AppointmentPage : Page
{
    public AppointmentPage(Appointment appointment, DoctorWindow window, Account account, IServiceProvider serviceProvider)
    {
        InitializeComponent();
        DataContext = new AppointmentPageViewModel(appointment, this, window, account, serviceProvider);
    }
}