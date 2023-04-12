using MedicalCentre.Models;
using MedicalCentre.ViewModels.DoctorWindowPagesViewModels;
using MedicalCentre.Views;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Controls;

namespace MedicalCentre.Pages.DoctorWindowPages;

public partial class AppointmentPage : Page
{
    public AppointmentPage(Appointment appointment, DoctorWindow window, Account account, IServiceCollection services)
    {
        InitializeComponent();
        DataContext = new AppointmentPageViewModel(appointment, this, window, account, services);
    }
}