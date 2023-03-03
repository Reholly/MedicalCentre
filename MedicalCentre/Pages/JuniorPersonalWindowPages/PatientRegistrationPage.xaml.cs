using MedicalCentre.ViewModels.JuniorPersonalWindowPagesViewModels;
using System.Windows.Controls;

namespace MedicalCentre.Pages.JuniorPersonalWindowPages
{
    public partial class PatientRegistrationPage : Page
    {
        public PatientRegistrationPage()
        {
            InitializeComponent();
            DataContext = new PatientRegistretionPageViewModel(this);
        }
    }
}