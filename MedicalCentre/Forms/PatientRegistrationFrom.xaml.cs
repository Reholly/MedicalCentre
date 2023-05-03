using System;
using System.Windows;
using MedicalCentre.ViewModels.FormsViewModels;


namespace MedicalCentre.Forms
{
    public partial class PatientRegistrationFrom : Window
    {
        public PatientRegistrationFrom(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            DataContext = new PatientRegistrationFormViewModel(this, serviceProvider);
        }
    }
}