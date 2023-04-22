using MedicalCentre.FormsViewModels;
using System;
using System.Windows;

namespace MedicalCentre.Forms;

public partial class EmployeeRegistration : Window
{
    public EmployeeRegistration(IServiceProvider serviceProvider)
    {
        InitializeComponent();
        DataContext = new EmployeeRegistrationViewModel(this, serviceProvider);
    }
}
