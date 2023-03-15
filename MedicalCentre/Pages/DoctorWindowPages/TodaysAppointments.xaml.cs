using MedicalCentre.ViewModels.DoctorWindowPagesViewModels;
using System.Windows.Controls;
using MedicalCentre.Windows;

namespace MedicalCentre.Pages.DoctorWindowPages
{
    public partial class TodaysAppointments : Page
    {
        public TodaysAppointments(DoctorWindow window)
        {
            InitializeComponent();
            DataContext = new TodaysAppointmentsPageViewModel(window);
        }
    }
}