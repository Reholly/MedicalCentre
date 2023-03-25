﻿using MedicalCentre.DatabaseLayer;
using MedicalCentre.Models;
using MedicalCentre.TelegramBot.DataBaseLayer;
using MedicalCentre.TelegramBot.Models;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using User = MedicalCentre.TelegramBot.Models.User;

namespace MedicalCentre.TelegramBot.Controllers.MessageController.Commands
{
    internal class AppoitmentHistoryCommand : Command
    {
        public override string Name => "История";

        protected override TelegramBotClient client => Bot.GetTelegramBot();

        public override void Execute(Update update)
        {
            var chatId = update.Message.Chat.Id;
            Database<Appointment> dbAppointment = new Database<Appointment>();
            List<Appointment> appointments = dbAppointment.GetTable();

            User? user = DatabaseTelegram.Users.Find(x => x.ChatId == chatId);
            if (user == null)
            {
                KeyboardButton regsterBtn = new KeyboardButton("Регистрация");
                var regsterMarkup = new ReplyKeyboardMarkup(regsterBtn)
                {
                    ResizeKeyboard = true,
                    OneTimeKeyboard = true
                };
                client.SendTextMessageAsync(update.Message.Chat.Id, "Для начала работы зарегестрируйтесь или авторизуйтесь!", replyMarkup: regsterMarkup);
                return;
            }

            Database<Employee> dbEmployee = new Database<Employee>();
            Database<Patient> dbPatient = new Database<Patient>();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("История посещений");
            foreach (var appointment in appointments)
            {
                if (appointment.PatientId == null)
                    continue;

                if (dbPatient.GetItemById((uint)appointment.PatientId).PhoneNumber == user.PhoneNumber && appointment.IsFinished)
                {
                    sb.AppendLine($"{appointment.AppointmentTime} - {dbEmployee.GetItemById(appointment.DoctorId).Surname} " +
                                  $"{dbEmployee.GetItemById(appointment.DoctorId).Name} " +
                                  $"({dbEmployee.GetItemById(appointment.DoctorId).Specialization})");
                }
            }

            client.SendTextMessageAsync(chatId, sb.ToString());
        }
    }
}
