using MedicalCentre.Models;
using MedicalCentre.ViewModels.DoctorWindowPagesViewModels;
using MedicalCentre.Windows;
using System.Windows.Controls;

namespace MedicalCentre.Pages.DoctorWindowPages
{
    public partial class AppointmentPage : Page
    {
        public AppointmentPage(Appointment appointment, DoctorWindow window, Account account)
        {
            InitializeComponent();
            DataContext = new AppointmentPageViewModel(appointment, this, window, account);
        }
    }
}