using MedicalCentre.DatabaseLayer;
using MedicalCentre.Models;
using System.Windows.Controls;

namespace MedicalCentre.Services
{
    public static class EmployeeNameBinderService
    {
        public static void BindName(uint employeeId, TextBlock RoleName, TextBlock EmployeeName)
        {
            ContextRepository<Role> roleDb = new ContextRepository<Role>();
            ContextRepository<Employee> employeeDb = new ContextRepository<Employee>();
            Employee currentEmployee = employeeDb.GetItemById(employeeId);
            string role = roleDb.GetItemById(currentEmployee.RoleId).Title;

            RoleName.Text = role;
            EmployeeName.Text = $" {currentEmployee.Name} {currentEmployee.Patronymic}";
        }
    }
}
