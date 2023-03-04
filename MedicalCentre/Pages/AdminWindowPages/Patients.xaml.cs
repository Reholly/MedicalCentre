using MedicalCentre.ViewModels.AdminWindowPagesViewModels;
using System.Windows.Controls;

namespace MedicalCentre.Pages.AdminWindowPages
{
    public partial class PatientsPage : Page
    {
        public PatientsPage()
        {
            InitializeComponent();
            DataContext = new PatientsViewModel(this);
        }
    }
}