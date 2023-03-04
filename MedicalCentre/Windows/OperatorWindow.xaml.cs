using MedicalCentre.Services;
using MedicalCentre.ViewModels;
using System.Windows;

namespace MedicalCentre.Windows
{
    public partial class OperatorWindow : Window
    {
        public OperatorWindow(uint employeeId)
        {
            InitializeComponent();
            EmployeeNameBinderService.BindName(employeeId, RoleName, EmployeeName);
            DataContext = new OperatorWindowViewModel(this);
        }
    }
}