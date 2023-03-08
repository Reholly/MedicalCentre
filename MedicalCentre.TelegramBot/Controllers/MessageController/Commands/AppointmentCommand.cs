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
        private string? doctorSurname = null;
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

            Database<Employee> dbEmployee = new Database<Employee>();
            Database<Patient> dbPatient = new Database<Patient>();

            Database<Appointment> dbAppointment = new Database<Appointment>();
            appointments = dbAppointment.GetTable().Where(x => x.PatientId == null).ToList();
            if (appointments.Count == 0)
            {
                client.SendTextMessageAsync(chatId, "На данный момент нет записей!");
                Executor.StopListen();
                return;
            }

            var specializationsBtn = appointments.Select(x => dbEmployee.GetItemById(x.DoctorId).Specialization)
                                                 //.Distinct()
                                                 .Select(x => new KeyboardButton(x))
                                                 .ToArray();

            var specializationMarkup = new ReplyKeyboardMarkup(specializationsBtn)
            {
                ResizeKeyboard = true,
                OneTimeKeyboard = true
            };
            client.SendTextMessageAsync(update.Message.Chat.Id, "Выеберите специальность врача", replyMarkup: specializationMarkup);
            Executor.StartListen(this);
        }

        public void GetUpdate(Update update)
        {
            Database<Employee> dbEmployee = new Database<Employee>();
            Database<Patient> dbPatient = new Database<Patient>();
            if (doctorSpecialization == null)
            {
                doctorSpecialization = update.Message.Text;
                var appointmentsTmp = appointments.Where(x => dbEmployee.GetItemById(x.DoctorId).Specialization == doctorSpecialization).ToList();
                if(appointmentsTmp.Count == 0)
                {
                    client.SendTextMessageAsync(update.Message.Chat.Id, "На данную специализацию нет записей!");
                }
                appointments = appointmentsTmp;

                var specializationBtn = appointments.Select(x => new KeyboardButton(dbEmployee.GetItemById(x.DoctorId).Surname)).ToArray();
                var specializationMarkup = new ReplyKeyboardMarkup(specializationBtn)
                {
                    ResizeKeyboard = true,
                    OneTimeKeyboard = true
                };
                client.SendTextMessageAsync(update.Message.Chat.Id, "Выеберите врача", replyMarkup: specializationMarkup);
            }
            else if(doctorSurname == null)
            {
                doctorSurname = update.Message.Text;
                var appointmentsTmp = appointments.Where(x => dbEmployee.GetItemById(x.DoctorId).Surname == doctorSurname).ToList();
                if (appointmentsTmp.Count == 0)
                {
                    client.SendTextMessageAsync(update.Message.Chat.Id, "К данному врачу нет записей!");
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
                    client.SendTextMessageAsync(update.Message.Chat.Id, "На данное время нет записей!");
                }
                appointment.PatientId = DatabaseTelegram.Users.Find(x => x.ChatId == update.Message.Chat.Id).Id;
                Database<Appointment> db = new Database<Appointment>();
                db.UpdateItemAsync(appointment);

                client.SendTextMessageAsync(update.Message.Chat.Id, "Вы успешно записанны");
                Executor.StopListen();
            }
        }
    }
}
