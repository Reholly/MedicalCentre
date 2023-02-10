using MedicalCentre.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalCentre.DatabaseLayer
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Image> Images { get; set; } 
        public DbSet<MedicalExamination> MedicalExaminations { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Role> Roles { get; set; }

        public ApplicationContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string databaseSettings = Properties.Settings.Default.DatabaseSettings;
            optionsBuilder.UseMySql(databaseSettings, ServerVersion.AutoDetect(databaseSettings));
        }
    }
}
