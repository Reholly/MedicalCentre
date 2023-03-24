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
        }

        private async Task SaveChanges()
        {

        }
    }
}