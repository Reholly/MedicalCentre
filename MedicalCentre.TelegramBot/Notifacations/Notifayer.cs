using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using MedicalCentre.TelegramBot.Models;
using MedicalCentre.TelegramBot.DataBaseLayer;
using MedicalCentre.DatabaseLayer;
using MedicalCentre.Models;
using MedicalCentre.TelegramBot.Controllers.MessageController.Commands;

namespace MedicalCentre.TelegramBot.Notifacations
{
    internal class Notifayer
    {
        private TelegramBotClient client = Bot.GetTelegramBot();

        public async Task SendAllNotifacates()
        {
            Logger.Log("Notification sended to all users");

            Database<Appointment> dbAppointment = new Database<Appointment>();

            Database<Employee> dbEmployee = new Database<Employee>();
            Database<Patient> dbPatient = new Database<Patient>();

            List<Appointment> appointments = dbAppointment.GetTable()
                                                          .Where(x => (x.AppointmentTime.Date.Day - DateTime.Now.Day == 1 && x.AppointmentTime.Month == DateTime.Now.Month)).ToList();
            foreach(var appointment in appointments)
            {
                if (appointment.PatientId == null)
                    continue;

                User? user = DatabaseTelegram.Users.Find(x => x.PhoneNumber == dbPatient.GetItemById((uint)appointment.PatientId).PhoneNumber);
                if(user == null) 
                {
                    continue;
                }

                await client.SendTextMessageAsync(user.ChatId, $"У вас запись у {dbEmployee.GetItemById(appointment.DoctorId).Name} " +
                                                               $"({dbEmployee.GetItemById(appointment.DoctorId).Specialization}) на " +
                                                               $"{appointment.AppointmentTime}!");
            }
        }
    }
}
