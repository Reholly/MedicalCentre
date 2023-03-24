using MedicalCentre.Forms;
using MedicalCentre.Models;
using MedicalCentre.ViewModels;
using System.Windows.Input;

namespace MedicalCentre.UserControls.ViewModels
{
    internal class PatientCardViewModel
    {
        public ICommand? ProfileCommand { get; set; }
        private Patient currentPatient;
        public PatientCardViewModel(PatientCard card, Patient patient)
        {
            currentPatient = patient;
            ProfileCommand = new RelayCommand(OpenProfile);
            card.Card.Text = patient.ToString();
        }
        private void OpenProfile()
        {
            PatientProfile profile = new(currentPatient);
            profile.Show();
        }
    }
}
