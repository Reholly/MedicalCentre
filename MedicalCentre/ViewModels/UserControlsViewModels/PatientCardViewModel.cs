using System;
using System.Windows.Input;
using MedicalCentre.Forms;
using MedicalCentre.Models;
using MedicalCentre.UserControls;
using MedicalCentre.ViewModels.Commands;

namespace MedicalCentre.ViewModels.UserControlsViewModels
{
    internal class PatientCardViewModel
    {
        public ICommand ProfileCommand { get; set; }
        private readonly Patient currentPatient;
        private readonly IServiceProvider provider;
        public PatientCardViewModel(PatientCard card, Patient patient, IServiceProvider provider)
        {
            currentPatient = patient;
            this.provider = provider;
            ProfileCommand = new RelayCommand(OpenProfile);
            card.Card.Text = patient.ToString();
        }
        private void OpenProfile()
        {
            PatientProfile profile = new(currentPatient, provider);
            profile.Show();
        }
    }
}
