using System;
using System.Collections.Generic;
using System.Windows;
using MedicalCentre.Models;
using MedicalCentre.ViewModels.FormsViewModels;

namespace MedicalCentre.Forms
{
    public partial class AppointmentWritingForm : Window
    {
        public AppointmentWritingForm(IServiceProvider serviceProvider, List<Patient> patients, List<string> appointments)
        {
            InitializeComponent();
            DataContext = new AppointmentWritingFormViewModel(this, serviceProvider, patients, appointments);
        }
    }
}
