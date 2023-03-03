using MedicalCentre.Models;
using MedicalCentre.Pages.JuniorPersonalWindowPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;

namespace MedicalCentre.ViewModels.JuniorPersonalWindowPagesViewModels
{
    public class ExaminationPageViewModel
    {
        private readonly ExaminationPage page;
        private Patient patient = null; 
        public ICommand RegistratePatientCommand { get; set; }
        public ExaminationPageViewModel(ExaminationPage page)
        {
            this.page = page;
        }

        private void RegistratePatient()
        {
            NavigationWindow navigationWindow = new();
            navigationWindow.Content = new PatientRegistrationPage();
            navigationWindow.Show();
        }
    }
}
