using MedicalCentre.Models;
using MedicalCentre.ViewModels.DoctorWindowPagesViewModels;
using MedicalCentre.Views;
using System;
using System.Windows.Controls;

namespace MedicalCentre.Pages.DoctorWindowPages;

public partial class AppointmentPage : Page
{
    public AppointmentPage(Appointment appointment, DoctorWindow window, Account account, IServiceProvider serviceProvider)
    {
        InitializeComponent();
        DataContext = new AppointmentPageViewModel(appointment, this, window, account, serviceProvider);
    }
}