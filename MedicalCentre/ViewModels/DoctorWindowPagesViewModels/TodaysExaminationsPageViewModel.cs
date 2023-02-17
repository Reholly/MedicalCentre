using MedicalCentre.Models;
using MedicalCentre.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MedicalCentre.ViewModels.DoctorWindowPagesViewModels
{
    public class TodaysExaminationsPageViewModel
    {
        public ObservableCollection<MedicalExamination> Examinations { get; set; } = new();
        public MedicalExamination SelectedExamination { get; set; }
        public ICommand AddExaminationCommand { get; set; }
        public TodaysExaminationsPageViewModel()
        {
            AddExaminationCommand = new RelayCommand(AddExamination);
        }

        private void AddExamination() => Examinations.Add(new MedicalExamination());
    }
}
