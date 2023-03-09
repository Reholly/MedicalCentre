using MedicalCentre.Models;
using MedicalCentre.ViewModels.DoctorWindowPagesViewModels;
using System.Windows.Controls;

namespace MedicalCentre.Pages.DoctorWindowPages
{
    public partial class CreateExaminationPage : Page
    {
        public MedicalExamination CreatedExamination { get; set; }
        public Patient Patient { get; set; }
        public CreateExaminationPage(Patient patient)
        {
            InitializeComponent();
            DataContext = new CreateExaminationPageViewModel(this, patient);
        }
    }
}