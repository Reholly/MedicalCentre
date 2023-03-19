using MedicalCentre.ViewModels.DoctorWindowPagesViewModels;
using System.Windows.Controls;

namespace MedicalCentre.Pages.DoctorWindowPages
{
    public partial class DoctorMainPage : Page
    {
        public DoctorMainPage()
        {
            InitializeComponent();
            DataContext = new DoctorMainPageViewModel(this);
        }
    }
}