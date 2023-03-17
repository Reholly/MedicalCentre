using MedicalCentre.DatabaseLayer;
using MedicalCentre.Forms.ViewModels;
using MedicalCentre.Models;
using MedicalCentre.Services;
using System;
using System.Globalization;
using System.Windows;

namespace MedicalCentre.Forms
{
    public partial class CreateAppointment : Window
    {
        public CreateAppointment()
        {
            InitializeComponent();
            DataContext = new CreateAppointmentViewModel(this);
        }
    }
}
