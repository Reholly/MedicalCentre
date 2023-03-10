using MedicalCentre.Forms.ViewModels;
using System.Windows;


namespace MedicalCentre.Forms
{
    public partial class PatientRegistration : Window
    {
        public PatientRegistration()
        {
            InitializeComponent();
            DataContext = new PatientRegistrationViewModel(this);
        }
    }
}
