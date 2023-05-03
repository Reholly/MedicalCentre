using System;
using MedicalCentre.Models;
using System.Windows.Controls;
using MedicalCentre.ViewModels.UserControlsViewModels;

namespace MedicalCentre.UserControls;

public partial class EmployeeCard : UserControl
{
    public EmployeeCard(Employee employee, IServiceProvider provider)
    {
        InitializeComponent();
        DataContext = new EmployeeCardViewModel(this, employee, provider);
    }
}
