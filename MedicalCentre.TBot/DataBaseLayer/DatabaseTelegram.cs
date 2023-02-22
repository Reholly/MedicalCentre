﻿using MedicalCentre.DatabaseLayer;
using MedicalCentre.Models;
using MedicalCentre.TelegramBot.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCentre.TelegramBot.DataBaseLayer
{
    internal class DatabaseTelegram
    {
        private Database<Patient> patientsDb;
        private Database<Employee> employeeDb;

        public List<Patient> patients => patientsDb.GetTable();
        public List<Employee> Employees => employeeDb.GetTable();

        public DatabaseTelegram()
        {
            patientsDb = new Database<Patient>();
            employeeDb = new Database<Employee>();
        }

        public static List<User> Users { get; } = new List<User>();

        public void AutorizeUser(User user)
        {
            Users.Add(user);
        }
        public void RegisterUser(User user)
        {     
            patientsDb.AddItem(user.GetAsPatient());
            Users.Add(user);
        }
    }
}