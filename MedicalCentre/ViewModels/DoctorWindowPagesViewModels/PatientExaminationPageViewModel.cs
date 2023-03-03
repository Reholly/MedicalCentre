using MedicalCentre.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MedicalCentre.ViewModels.DoctorWindowPagesViewModels
{
    public class PatientExaminationPageViewModel
    {
        public ObservableCollection<MedicalExamination> Examinations { get; set; }
        public PatientExaminationPageViewModel(List<MedicalExamination> examinations)
        {
            Examinations = new ObservableCollection<MedicalExamination>(examinations);
        }
    }
}