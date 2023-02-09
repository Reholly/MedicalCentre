using MedicalCentre.Models;

namespace MedicalCentre.DatabaseLayer
{
    public class DatabaseInteraction
    {
        private ApplicationContext context;

        public DatabaseInteraction()
        {
            context = new ApplicationContext();
        }

        public async void AddEmployee(Employee employee)
        {
            using (context)
            {
                await context.Employees.AddAsync(employee);
                await context.SaveChangesAsync();
            }
        }
    }
}
