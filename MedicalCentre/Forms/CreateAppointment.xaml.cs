using MedicalCentre.FormsViewModels;
using System;
using System.Windows;

namespace MedicalCentre.Forms;

public partial class CreateAppointment : Window
{
    public CreateAppointment(IServiceProvider serviceProvider)
    {
        InitializeComponent();
        DataContext = new CreateAppointmentViewModel(this, serviceProvider);
    }
}
