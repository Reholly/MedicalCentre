using MedicalCentre.DatabaseLayer;
using MedicalCentre.Models;
using MedicalCentre.Pages.DoctorWindowPages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MedicalCentre.ViewModels.DoctorWindowPagesViewModels
{
    public class CreateExaminationPageViewModel
    {
        private readonly CreateExaminationPage page;
        private readonly Patient patient;
        public ICommand SaveExaminationCommand { get; set; }
        public CreateExaminationPageViewModel(CreateExaminationPage page, Patient patient)
        {
            this.page = page;
            this.patient = patient;
            SaveExaminationCommand = new RelayCommandAsync(SaveExamination);
        }

        private async Task SaveExamination()
        {
            ContextRepository<MedicalExamination> tempRepository = new();
            List<MedicalExamination> examinations = await tempRepository.GetTableAsync();
            MedicalExamination examination = new((uint)examinations.Count + 1, DateTime.Now, patient, page.ExaminationTitleBox.Text, page.ExaminationTextBox.Text, null);
            ContextRepository<Patient> repository = new();
            patient.Examinations.Add(examination);
            await repository.UpdateItemAsync(patient);
        }
    }
}