using MedicalCentre.Forms;
using MedicalCentre.Models;
using MedicalCentre.ViewModels;
using System.Windows.Input;

namespace MedicalCentre.UserControls.ViewModels
{
    internal class EmployeeCardViewModel
    {
        public ICommand? ProfileCommand { get; set; }
        private Employee currentEmployee;
        public EmployeeCardViewModel(EmployeeCard card, Employee employee)
        {
            currentEmployee = employee;
            ProfileCommand = new RelayCommand(OpenProfile);
            card.Card.Text = employee.ToString();
        }
        private void OpenProfile()
        {
            EmployeeProfile profile = new(currentEmployee);
            profile.Show();
        }
    }
}
