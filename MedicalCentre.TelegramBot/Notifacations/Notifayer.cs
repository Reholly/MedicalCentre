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

namespace MedicalCentre.TelegramBot.Notifacations
{
    internal class Notifayer
    {
        private TelegramBotClient client = Bot.GetTelegramBot();
        private DateTime date;
            
        public Notifayer(DateTime date) 
        {
            this.date = date;
        }

        public async Task SendAllNotifacates()
        {
            Logger.Log("Notification sended to all users");

            Database<Appointment> dbAppointment = new Database<Appointment>();
            //Database<MedicalExamination> dbMedicalExamination = new Database<MedicalExamination>();

            List<Appointment> appointments = dbAppointment.GetTable().Where(x => (x.AppointmentTime.Date - date).Days == 1).ToList();
            foreach(var appointment in appointments)
            {
                User? user = DatabaseTelegram.Users.Find(x => x.PhoneNumber == appointment.Patient.PhoneNumber);
                if(user == null) 
                {
                    continue;
                }
                client.SendTextMessageAsync(user.ChatId, $"У вас запись у {appointment.Doctor.Name} ({appointment.Doctor.Specialization}) на {appointment.AppointmentTime}!");
            }
        }
    }
}
