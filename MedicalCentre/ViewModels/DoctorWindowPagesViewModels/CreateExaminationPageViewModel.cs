using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MedicalCentre.Models;
using MedicalCentre.Pages.DoctorWindowPages;
using System.Windows.Controls;

namespace MedicalCentre.ViewModels.DoctorWindowPagesViewModels
{
    public class CreateExaminationPageViewModel
    {
        private readonly CreateExaminationPage page;
        private ImageData Images = new();
        public ICommand SaveExaminationCommand { get; set; }
        public CreateExaminationPageViewModel(CreateExaminationPage page)
        {
            this.page = page;
            SaveExaminationCommand = new RelayCommand(SaveExamination);
        }

        private void SaveExamination()
        {
            page.CreatedExamination = new MedicalExamination(page.Patient, page.ExaminationTitleBox.Text, page.ExaminationTextBox.Text, Images, DateTime.Now);
            page.IsCreated = true;
        }
    }
}
