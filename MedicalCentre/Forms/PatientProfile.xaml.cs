using System;
using MedicalCentre.Models;
using System.Windows;
using MedicalCentre.ViewModels.FormsViewModels;

namespace MedicalCentre.Forms
{
    public partial class PatientProfile : Window
    {
        public PatientProfile(Patient patient, IServiceProvider provider)
        {
            InitializeComponent();
            DataContext = new PatientProfileViewModel(this, patient, provider);
        }
    }
}
