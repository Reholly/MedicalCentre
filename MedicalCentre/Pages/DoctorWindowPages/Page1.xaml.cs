using MedicalCentre.ViewModels.DoctorWindowPagesViewModels;
using System.Windows.Controls;

namespace MedicalCentre.Pages.DoctorWindowPages
{
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
            DataContext = new Page1ViewModel();
        }
    }
}