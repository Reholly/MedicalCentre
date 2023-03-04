using MedicalCentre.ViewModels.DoctorWindowPagesViewModels;
using System.Windows.Controls;

namespace MedicalCentre.Pages.DoctorWindowPages
{
    public partial class TodaysAppointmentsPage : Page
    {
        public TodaysAppointmentsPage()
        {
            InitializeComponent();
            DataContext = new TodaysAppointmentsPageViewModel();
        }
    }
}