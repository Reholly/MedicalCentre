using MedicalCentre.Models;
using System.Windows.Input;

namespace MedicalCentre.FormsViewModels
{
    internal class EmployeeProfileViewModel
    {
        private Employee currentEmployee;
        public ICommand? SaveCommand { get; set; }
        public ICommand? DeleteCommand { get; set; }
        public EmployeeProfileViewModel(Employee employee)
        {
            currentEmployee = employee;
        }
    }
}
