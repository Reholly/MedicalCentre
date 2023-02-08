using MedicalCentre.Roles;
using Microsoft.EntityFrameworkCore;

namespace MedicalCentre.Models
{
    public class ApplicationContext : DbContext
    {
        private DbSet<Employee> employees { get; set; }
        private DbSet<Log> logs { get; set; }
        private DbSet<MedicalExamination> medicalExaminations { get; set; }
        private DbSet<Note> notes { get; set; }
        private DbSet<Patient> patiens { get; set; }
        private DbSet<Role> roles { get; set; }
        private DbSet<Specialization> specializations { get; set; }

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
