using MedicalCentre.ViewModels.AdminWindowPagesViewModels;
using System.Windows.Controls;

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
