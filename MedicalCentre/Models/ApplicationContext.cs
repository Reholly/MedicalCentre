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
        private DbSet<Specialization> specializations = null!;
        private DbSet<IRole> roles = null!;

        public ApplicationContext()
        {
            Database.EnsureCreatedAsync();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=sql7.freesqldatabase.com;user=sql7596671;password=ZekcL6nf9m;database=sql7596671;",
                                    ServerVersion.AutoDetect("server=sql7.freesqldatabase.com;user=sql7596671;password=ZekcL6nf9m;database=sql7596671;"));
        }

    }
}
