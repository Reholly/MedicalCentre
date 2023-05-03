using MedicalCentre.FormsViewModels;
using System;
using System.Windows;

namespace MedicalCentre.Forms;

public partial class EmployeeRegistrationForm : Window
{
    public EmployeeRegistrationForm(IServiceProvider serviceProvider)
    {
        InitializeComponent();
        DataContext = new EmployeeRegistrationFormViewModel(this, serviceProvider);
    }
}
