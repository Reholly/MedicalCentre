using MedicalCentre.DatabaseLayer;
using MedicalCentre.Forms.ViewModels;
using MedicalCentre.Models;
using MedicalCentre.Services;
using System;
using System.Windows;

namespace MedicalCentre.Forms
{
    public partial class WriteAppointment : Window
    {
        public WriteAppointment()
        {
            InitializeComponent();
            DataContext = new WriteAppointmentViewModel(this);
        }
    }
}
