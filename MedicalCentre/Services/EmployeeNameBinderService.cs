using MedicalCentre.DatabaseLayer;
using MedicalCentre.Models;
using System.Windows.Controls;

namespace MedicalCentre.Services;

public static class EmployeeNameBinderService
{
    public static void BindName(Account account, TextBlock RoleName, TextBlock EmployeeName)
    {
        ContextRepository<Employee> employeeDb = new ContextRepository<Employee>();
        Employee currentEmployee = employeeDb.GetItemById(account.EmployeeAccountId);

        RoleName.Text = account.Role.ToString();
        EmployeeName.Text = $" {currentEmployee.Name} {currentEmployee.Patronymic}";
    }
}