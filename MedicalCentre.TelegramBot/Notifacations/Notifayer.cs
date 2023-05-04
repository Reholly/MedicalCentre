using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using MedicalCentre.TelegramBot.Models;
using MedicalCentre.DatabaseLayer;
using MedicalCentre.Models;
using MedicalCentre.TelegramBot.Controllers.MessageController.Commands;

namespace MedicalCentre.TelegramBot.Notifacations
{
    public class Notifayer
    {
        private TelegramBotClient client = Bot.GetTelegramBot();

        public async Task SendAllNotifacates()
        {
            Logger.Log("Notification sended to all users");

            ContextRepository<Appointment> dbAppointment = new ContextRepository<Appointment>();

            ContextRepository<Employee> dbEmployee = new ContextRepository<Employee>();
            ContextRepository<Patient> dbPatient = new ContextRepository<Patient>();

            List<Appointment> appointments = dbAppointment.GetTableAsync().Result
                                                          .Where(x => (x.AppointmentTime.Date.Day - DateTime.Now.Day == 1 && x.AppointmentTime.Month == DateTime.Now.Month)).ToList();
            foreach(var appointment in appointments)
            {
                if (appointment.PatientId == null)
                {
                    continue;
                }

                string phone = dbPatient.GetItemByIdAsync((uint)appointment.PatientId).Result.PhoneNumber;
                User? user = UserManager.GetUserByPhone(phone);

                if(user == null) 
                {
                    continue;
                }

                await client.SendTextMessageAsync(user.ChatId, $"У вас запись у {dbEmployee.GetItemByIdAsync(appointment.DoctorId).Result.Surname} " +
                                                               $"({dbEmployee.GetItemById(appointment.DoctorId).Specialization}) на " +
                                                               $"{appointment.AppointmentTime}!");
            }
        }
    }
}
