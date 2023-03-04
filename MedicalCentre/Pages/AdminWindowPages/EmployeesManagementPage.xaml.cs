using System.Windows.Controls;
using MedicalCentre.ViewModels.AdminWindowPagesViewModels;

namespace MedicalCentre.Pages.AdminWindowPages
{
    public partial class EmployeesManagementPage : Page
    {
        public EmployeesManagementPage()
        {
            InitializeComponent();
            DataContext = new EmployeeManagementViewModel(this);
        }
    }
}
