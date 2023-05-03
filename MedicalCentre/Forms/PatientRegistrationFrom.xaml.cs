using System.Windows;
using MedicalCentre.ViewModels.FormsViewModels;


namespace MedicalCentre.Forms
{
    public partial class PatientRegistrationFrom : Window
    {
        public PatientRegistrationFrom()
        {
            InitializeComponent();
            DataContext = new PatientRegistrationFormViewModel(this);
        }
    }
}