using System.Windows.Controls;
using MedicalCentre.Models;
using MedicalCentre.ViewModels.DoctorWindowPagesViewModels;

namespace MedicalCentre.Pages.DoctorWindowPages
{
    public partial class PatientInfoPage : Page
    {
        public PatientInfoPage(Patient patinet)
        {
            InitializeComponent();
            DataContext = new PatientInfoPageViewModel(patinet, this);
        }
    }
}
