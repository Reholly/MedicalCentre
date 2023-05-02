using MedicalCentre.FormsViewModels;
using System;
using System.Windows;

namespace MedicalCentre.Forms
{
    public partial class WriteAppointment : Window
    {
        public WriteAppointment(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            DataContext = new WriteAppointmentViewModel(this, serviceProvider);
        }
    }
}
