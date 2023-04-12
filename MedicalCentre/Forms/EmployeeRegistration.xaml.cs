using MedicalCentre.FormsViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace MedicalCentre.Forms;

public partial class EmployeeRegistration : Window
{
    public EmployeeRegistration(IServiceCollection services)
    {
        InitializeComponent();
        DataContext = new EmployeeRegistrationViewModel(this, services);
    }
}
