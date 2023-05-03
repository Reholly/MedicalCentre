using System;
using System.Windows;
using MedicalCentre.ViewModels.FormsViewModels;

namespace MedicalCentre.Forms;

public partial class EmployeeRegistrationForm : Window
{
    public EmployeeRegistrationForm(IServiceProvider serviceProvider)
    {
        InitializeComponent();
        DataContext = new EmployeeRegistrationFormViewModel(this, serviceProvider);
    }
}
