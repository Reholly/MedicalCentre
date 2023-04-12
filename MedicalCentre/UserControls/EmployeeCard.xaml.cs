using MedicalCentre.Models;
using MedicalCentre.UserControls.ViewModels;
using System.Windows.Controls;

namespace MedicalCentre.UserControls;

public partial class EmployeeCard : UserControl
{
    public EmployeeCard(Employee employee)
    {
        InitializeComponent();
        DataContext = new EmployeeCardViewModel(this, employee);
    }
}
