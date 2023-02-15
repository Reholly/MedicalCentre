using MedicalCentre.DatabaseLayer;
using MedicalCentre.Models;
using MedicalCentre.TelegramBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCentre.TelegramBot.DataBaseLayer
{
    internal class DataBaseTelegram
    {
        private List<Patient> patients;
        private List<Employee> employee;

        public DataBaseTelegram() 
        {
            Database<Patient> patientsDb = new Database<Patient>();
            Database<Employee> employeeDb = new Database<Employee>();
            patients = patientsDb.GetTable();
            employee = employeeDb.GetTable();
        }

        public Patient? GetPatientByPhone(string phoneNumber)
        {
            return patients.Find(patient => patient.PhoneNumber == phoneNumber);
        }

        public void AddPatient(Patient patient)
        {
            patients.Add(patient);
        }
    }
}
