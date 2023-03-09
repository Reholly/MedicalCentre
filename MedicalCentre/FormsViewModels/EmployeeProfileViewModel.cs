using MedicalCentre.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
