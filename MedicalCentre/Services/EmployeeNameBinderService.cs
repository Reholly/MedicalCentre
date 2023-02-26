using MedicalCentre.DatabaseLayer;
using MedicalCentre.Models;
using System.Windows.Controls;

namespace MedicalCentre.Services
{
    public static class EmployeeNameBinderService
    {
        public static void BindName(uint employeeId, TextBlock RoleName, TextBlock EmployeeName)
        {
            Database<Role> roleDb = new Database<Role>();
            Database<Employee> employeeDb = new Database<Employee>();
            Employee currentEmployee = employeeDb.GetItemById(employeeId);
            string role = roleDb.GetItemById(currentEmployee.RoleId).Title;

            RoleName.Text = role;
            EmployeeName.Text = $" {currentEmployee.Name} {currentEmployee.Patronymic}";
        }
    }
}
