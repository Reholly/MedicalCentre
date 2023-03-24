using Aspose.Pdf.Annotations;
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
        public ICommand ClosingCommand { get; set; }
        public CreateExaminationFormViewModel(CreateExaminationForm form)
        {
            this.form = form;
            ChangesSavingCommand = new RelayCommand(SaveChanges);
            ClosingCommand = new RelayCommand(Close);
        }

        private void SaveChanges()
        {
            MedicalExamination examination = new MedicalExamination(
                uint.Parse(form.PatientsId.Text), 
                form.Title.Text,
                form.Conclusion.Text,
                null,
                DateTime.Now);
            ContextRepository<MedicalExamination> repository = new(); 
            repository.AddItem(examination);
            form.Close();
        }

        private void Close() => form.Close();
    }
}