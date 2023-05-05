using System;
using System.Collections.Generic;
using System.Windows;
using MedicalCentre.Models;
using MedicalCentre.ViewModels.FormsViewModels;

namespace MedicalCentre.Forms
{
    public partial class ExaminationCreatingForm : Window
    {
        public ExaminationCreatingForm(IServiceProvider provider, List<Patient> patients)
        {
            InitializeComponent();
            DataContext = new ExaminationCreatingFormViewModel(this, provider, patients);
        }
    }
}