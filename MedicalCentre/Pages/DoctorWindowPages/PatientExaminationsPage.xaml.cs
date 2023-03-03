using MedicalCentre.Models;
using MedicalCentre.ViewModels.DoctorWindowPagesViewModels;
using System.Collections.Generic;
using System.Windows.Controls;

namespace MedicalCentre.Pages.DoctorWindowPages
{
    public partial class PatientExaminationsPage : Page
    {
        public PatientExaminationsPage(List<MedicalExamination> examinations)
        {
            InitializeComponent();
            DataContext = new PatientExaminationPageViewModel(examinations);
        }
    }
}