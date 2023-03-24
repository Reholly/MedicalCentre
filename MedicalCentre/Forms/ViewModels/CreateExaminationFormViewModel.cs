using MedicalCentre.DatabaseLayer;
using MedicalCentre.Models;
using MedicalCentre.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MedicalCentre.Forms.ViewModels
{
    public class CreateExaminationFormViewModel
    {
        private readonly CreateExaminationForm form;
        public ICommand ChangesSavingCommand { get; set; }
        public CreateExaminationFormViewModel(CreateExaminationForm form)
        {
            this.form = form;
            ChangesSavingCommand = new RelayCommandAsync(SaveChanges);
        }

        private async Task SaveChanges()
        {
            MedicalExamination examination = new MedicalExamination(
                uint.Parse(form.PatientsId.Text), 
                form.Title.Text,
                form.Conclusion.Text,
                null,
                DateTime.Now);
            await new ContextRepository<MedicalExamination>().AddItemAsync(examination);
        }
    }
}