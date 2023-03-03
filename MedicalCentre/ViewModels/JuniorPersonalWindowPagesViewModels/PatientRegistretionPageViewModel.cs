using MedicalCentre.Pages.JuniorPersonalWindowPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalCentre.Models;
using System.Windows.Input;
using MedicalCentre.DatabaseLayer;

namespace MedicalCentre.ViewModels.JuniorPersonalWindowPagesViewModels
{
    public class PatientRegistretionPageViewModel
    {
        private readonly PatientRegistrationPage page;
        private Patient createdPatient = null;
        public ICommand CheckPatientByIdCommand { get; set; }
        public PatientRegistretionPageViewModel(PatientRegistrationPage page)
        {
            this.page = page;
            CheckPatientByIdCommand = new RelayCommandAsync(CheckPatientById);
        }
        public async Task CheckPatientById()
        {

        }
    }
}