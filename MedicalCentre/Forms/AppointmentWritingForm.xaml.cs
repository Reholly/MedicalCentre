using System;
using System.Windows;
using MedicalCentre.ViewModels.FormsViewModels;

namespace MedicalCentre.Forms
{
    public partial class AppointmentWritingForm : Window
    {
        public AppointmentWritingForm(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            DataContext = new AppointmentWritingFormViewModel(this, serviceProvider);
        }
    }
}
