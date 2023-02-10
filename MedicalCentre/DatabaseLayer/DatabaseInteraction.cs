using MedicalCentre.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

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
        public async void AddPatient(Patient patient)
        {
            using (context)
            {
                await context.Patients.AddAsync(patient);
                await context.SaveChangesAsync();
            }
        }

        public async void AddImage(Image image)
        {
            using (context)
            {
                await context.Images.AddAsync(image);
                await context.SaveChangesAsync();
            }
        }

        public async void AddLog(Log log)
        {
            using (context)
            {
                await context.Logs.AddAsync(log);
                await context.SaveChangesAsync();
            }
        }

        public async void AddMedicalExamination(MedicalExamination ex)
        {
            using (context)
            {
                await context.MedicalExaminations.AddAsync(ex);
                await context.SaveChangesAsync();
            }
        }

        public async void AddNote(Note note)
        {
            using (context)
            {
                await context.Notes.AddAsync(note);
                await context.SaveChangesAsync();
            }
        }

        public async void AddRole(Role role)
        {
            using (context)
            {
                await context.Roles.AddAsync(role);
                await context.SaveChangesAsync();
            }
        }

        public async Task<Employee> GetEmployee(Employee employee)
        {
            using (context)
            {
                foreach (Employee employeeInDb in context.Employees.ToList())
                {
                    if (employee.Id == employeeInDb.Id)
                    {
                        await Task.Delay(0);
                        return employeeInDb;
                    }
                }
            }

            throw new NullReferenceException();
        }

        public async Task<Image> GetImage(Image image)
        {
            using (context)
            {
                foreach (Image imageInDb in context.Images.ToList())
                {
                    if (image.Id == imageInDb.Id)
                    {
                        await Task.Delay(0);
                        return imageInDb;
                    }
                }
            }

            throw new NullReferenceException();
        }

        public async Task<Log> GetLog(Log log)
        {
            using (context)
            {
                foreach (Log logInDb in context.Logs.ToList())
                {
                    if (log.Id == logInDb.Id)
                    {
                        await Task.Delay(0);
                        return logInDb;
                    }
                }
            }

            throw new NullReferenceException();
        }

        public async Task<MedicalExamination> GetMedicalExamination(MedicalExamination examination)
        {
            using (context)
            {
                foreach (MedicalExamination medExamination in context.MedicalExaminations.ToList())
                {
                    if (examination.Id == medExamination.Id)
                    {
                        await Task.Delay(0);
                        return medExamination;
                    }
                }
            }

            throw new NullReferenceException();
        }

        public async Task<Note> GetMedicalExamination(Note note)
        {
            using (context)
            {
                foreach (var noteInDb in context.Notes.ToList())
                {
                    if (note.Id == noteInDb.Id)
                    {
                        await Task.Delay(0);
                        return noteInDb;
                    }
                }
            }

            throw new NullReferenceException();
        }

        public async Task<Patient> GetPatient(Patient patient)
        {
            using (context)
            {
                foreach (var patientInDb in context.Patients.ToList())
                {
                    if (patient.Id == patientInDb.Id)
                    {
                        await Task.Delay(0);
                        return patientInDb;
                    }
                }
            }

            throw new NullReferenceException();
        }

        public async Task<Role> GetRole(Role role)
        {
            using (context)
            {
                foreach (var roleInDb in context.Roles.ToList())
                {
                    if (role.Id == roleInDb.Id)
                    {
                        await Task.Delay(0);
                        return roleInDb;
                    }
                }
            }

            throw new NullReferenceException();
        }
    }
}
