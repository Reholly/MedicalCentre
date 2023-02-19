using MedicalCentre.ViewModels.DoctorWindowPagesViewModels;
using System.Windows.Controls;

namespace MedicalCentre.Pages.DoctorWindowPages
{
    public partial class AllPatientsPage : Page
    {
        public AllPatientsPage()
        {
            InitializeComponent();
            DataContext = new AllPatientsPageViewModel();
        }
    }
}