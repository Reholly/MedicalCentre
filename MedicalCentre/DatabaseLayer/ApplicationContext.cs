using MedicalCentre.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace MedicalCentre.DatabaseLayer;

public class ApplicationContext : DbContext
{
    private static readonly IConfiguration s_config = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: true)
        .AddEnvironmentVariables()
        .AddUserSecrets(typeof(ApplicationContext).Assembly)
        .Build();

    public DbSet<Account> Accounts { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Log> Logs { get; set; }
    public DbSet<ImageData> Images { get; set; }
    public DbSet<MedicalExamination> MedicalExaminations { get; set; }
    public DbSet<Note> Notes { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<StorageItem> StorageItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connstr = s_config.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("WHERE CONNSTR");
        optionsBuilder.UseMySql(connstr, ServerVersion.AutoDetect(connstr));
    }  
}
