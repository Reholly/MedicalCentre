using System.Windows.Input;
using MedicalCentre.Forms;
using MedicalCentre.Models;
using MedicalCentre.UserControls;
using MedicalCentre.ViewModels.Commands;

namespace MedicalCentre.ViewModels.UserControlsViewModels
{
    internal class PatientCardViewModel
    {
        public ICommand? ProfileCommand { get; set; }
        private readonly Patient currentPatient;
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
