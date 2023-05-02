using System;
using System.Collections.Generic;
using System.Windows;
using MedicalCentre.Models;
using MedicalCentre.ViewModels.FormsViewModels;

namespace MedicalCentre.Forms;

public partial class AppointmentCreatingForm : Window
{
    public AppointmentCreatingForm(List<Employee> doctors, IServiceProvider provider)
    {
        InitializeComponent();
        DataContext = new AppointmentCreatingFormViewModel(this, doctors, provider);
    }
}
