using MedicalCentre.ViewModels.DoctorWindowPagesViewModels;
using System.Windows.Controls;

namespace MedicalCentre.Pages.DoctorWindowPages
{
    public partial class TodaysAppointments : Page
    {
        public TodaysAppointments()
        {
            InitializeComponent();
            DataContext = new TodaysAppointmentsPageViewModel();
        }
    }
}
