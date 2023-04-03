using MedicalCentre.FormsViewModels;
using MedicalCentre.Models;
using System.Windows;

namespace MedicalCentre.Forms
{
    public partial class PatientProfile : Window
    {
        public PatientProfile(Patient patient)
        {
            InitializeComponent();
            DataContext = new PatientProfileViewModel(this, patient);
        }
    }
}
