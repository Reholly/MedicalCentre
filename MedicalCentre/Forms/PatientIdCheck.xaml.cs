using MedicalCentre.Models;
using MedicalCentre.ViewModels.JuniorPersonalWindowPagesViewModels;
using System.Windows;
using System;

namespace MedicalCentre.Forms
{
    public partial class PatientIdCheck : Window
    {
        public Patient CreatedPatient { get; set; }
        private readonly PatientCheckViewModel viewModel;
        public PatientIdCheck()
        {
            InitializeComponent();
            viewModel = new PatientCheckViewModel(this);
            DataContext = viewModel;
            CreatedPatient = viewModel.GetPatient();
        }
        public Patient Patient()
        {
            if (CreatedPatient != null)
                return CreatedPatient;
            else
                throw new InvalidOperationException();
        }
    }
}