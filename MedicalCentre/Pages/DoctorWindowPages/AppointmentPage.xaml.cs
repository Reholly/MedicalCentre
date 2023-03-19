using MedicalCentre.Models;
using MedicalCentre.ViewModels.DoctorWindowPagesViewModels;
using System.Windows.Controls;

namespace MedicalCentre.Pages.DoctorWindowPages
{
    public partial class AppointmentPage : Page
    {
        public AppointmentPage(Appointment appointment, DoctorMainPage mainPage)
        {
            InitializeComponent();
            DataContext = new AppointmentPageViewModel(appointment, this, mainPage);
        }
    }
}