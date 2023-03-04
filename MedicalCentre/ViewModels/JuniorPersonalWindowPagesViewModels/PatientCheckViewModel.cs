using MedicalCentre.DatabaseLayer;
using MedicalCentre.Forms;
using MedicalCentre.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MedicalCentre.ViewModels.JuniorPersonalWindowPagesViewModels
{
    public class PatientCheckViewModel
    {
        private PatientIdCheck page;
        private Patient createdPatient;
        public ICommand CheckCommand { get; set; }
        public PatientCheckViewModel(PatientIdCheck page)
        {
            this.page = page;
            CheckCommand = new RelayCommandAsync(Check);
        }

        private async Task Check()
        {
            ContextRepository<Patient> db = new();
            List<Patient> patients = await db.GetTableAsync();
            uint id = uint.Parse(page.Id.Text);
            foreach (Patient pat in patients)
            {
                if (pat.Id == id)
                {
                    createdPatient = pat;
                    break;
                }
            }
        }

        public Patient GetPatient()
        {
            if (createdPatient != null)
                return createdPatient;
            else
                throw new InvalidOperationException("");
        }
    }
}