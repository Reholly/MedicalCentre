using MedicalCentre.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MedicalCentre.ViewModels.DoctorWindowPagesViewModels
{
    public class PatientExaminationPageViewModel
    {
        public ObservableCollection<MedicalExamination> Examinations { get; set; }
        public PatientExaminationPageViewModel(IEnumerable<MedicalExamination> examinations)
        {
            Examinations = (ObservableCollection<MedicalExamination>)examinations;
        }
    }
}