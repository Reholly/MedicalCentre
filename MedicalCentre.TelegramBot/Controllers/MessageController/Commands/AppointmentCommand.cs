using MedicalCentre.DatabaseLayer;
using MedicalCentre.Models;
using MedicalCentre.TelegramBot.DataBaseLayer;
using MedicalCentre.TelegramBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using User = MedicalCentre.TelegramBot.Models.User;

namespace MedicalCentre.TelegramBot.Controllers.MessageController.Commands
{
    internal class AppointmentCommand : Command, IListener
    {
        public override string Name => "Запись";

        public CommandExecutor Executor { get; }

        protected override TelegramBotClient client => Bot.GetTelegramBot();

        public AppointmentCommand(CommandExecutor executor)
        {
            Executor = executor;
        }

        private string? doctorSpecialization = null;
        private string? doctorName = null;
        private string? appointmentTime = null;

        private List<Appointment> appointments;

        public override void Execute(Update update)
        {
            Message msg = update.Message;
            long chatId = msg.Chat.Id;
            client.SendTextMessageAsync(chatId, "");

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

            Database<Appointment> db = new Database<Appointment>();
            appointments = (List<Appointment>)db.GetTable().Where(x => x.Patient == null);

            var specializationsBtn = appointments.Select(x => x.Doctor.Specialization)
                                                 .Distinct()
                                                 .Select(x => new KeyboardButton(x))
                                                 .ToArray();

            var specializationMarkup = new ReplyKeyboardMarkup(specializationsBtn)
            {
                ResizeKeyboard = true,
                OneTimeKeyboard = true
            };
            client.SendTextMessageAsync(update.Message.Chat.Id, "Выеберите специальность врача", replyMarkup: specializationMarkup);

        }

        public void GetUpdate(Update update)
        {
            if(doctorSpecialization == null)
            {
                doctorSpecialization = update.Message.Text;
                var appointmentsTmp = appointments.Where(x => x.Doctor.Specialization == doctorSpecialization).ToList();
                if(appointmentsTmp.Count == 0)
                {
                    doctorSpecialization = null;
                    return;
                }
                appointments = appointmentsTmp;

                var specializationBtn = appointments.Select(x => new KeyboardButton(x.Doctor.Name)).ToArray();
                var specializationMarkup = new ReplyKeyboardMarkup(specializationBtn)
                {
                    ResizeKeyboard = true,
                    OneTimeKeyboard = true
                };
                client.SendTextMessageAsync(update.Message.Chat.Id, "Выеберите врача", replyMarkup: specializationMarkup);
            }
            else if(doctorName == null)
            {
                doctorName = update.Message.Text;
                var appointmentsTmp = appointments.Where(x => x.Doctor.Name == doctorName).ToList();
                if (appointmentsTmp.Count == 0)
                {
                    doctorName = null;
                    return;
                }
                appointments = appointmentsTmp;

                var doctorsBtn = appointments.Select(x => new KeyboardButton(x.AppointmentTime.ToString())).ToArray();
                var doctorsMarkup = new ReplyKeyboardMarkup(doctorsBtn)
                {
                    ResizeKeyboard = true,
                    OneTimeKeyboard = true
                };
                client.SendTextMessageAsync(update.Message.Chat.Id, "Выеберите время", replyMarkup: doctorsMarkup);
            }
            else
            {
                appointmentTime = update.Message.Text;
                Appointment? appointment = appointments.Find(x => x.AppointmentTime.ToString() == appointmentTime);
                if (appointment == null)
                {
                    appointmentTime = null;
                    return;
                }
                appointment.Patient = DatabaseTelegram.Users.Find(x => x.ChatId == update.Message.Chat.Id).GetAsPatient();
                Database<Appointment> db = new Database<Appointment>();
                db.UpdateItemAsync(appointment);

                client.SendTextMessageAsync(update.Message.Chat.Id, "Вы успешно записанны");
                Executor.StopListen();
            }
        }
    }
}
