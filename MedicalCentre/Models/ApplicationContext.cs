using MedicalCentre.Roles;
using Microsoft.EntityFrameworkCore;

namespace MedicalCentre.Models
{
    public class ApplicationContext : DbContext
    {
        private DbSet<Employee> employees = null!;
        private DbSet<Log> logs = null!;
        private DbSet<MedicalExamination> medicalExaminations = null!;
        private DbSet<Note> notes = null!;
        private DbSet<Patient> patiens = null!;
        private DbSet<IRole> roles = null!;
        private DbSet<Specialization> specializations = null!;       

        public ApplicationContext()
        {
            Database.EnsureCreatedAsync();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string databaseSettings = Properties.Settings.Default.DatabaseSettings;
            optionsBuilder.UseMySql(databaseSettings, ServerVersion.AutoDetect(databaseSettings));
        }
    }
}
