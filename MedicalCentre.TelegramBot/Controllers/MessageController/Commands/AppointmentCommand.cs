using MedicalCentre.DatabaseLayer;
using MedicalCentre.Models;
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
    internal class AppointmentCommand : ICommand, IListener
    {
        public string Name => "Запись";

        public CommandExecutor Executor { get; }

        public TelegramBotClient client => Bot.GetTelegramBot();

        public bool NeedAutorization => true;

        public AppointmentCommand(CommandExecutor executor)
        {
            Executor = executor;
        }

        private string? doctorSpecialization = null;
        private string? doctorSurname = null;
        private string? appointmentTime = null;

        private List<Appointment> appointments;

        private KeyboardButton[][] ToRows(KeyboardButton[] buttons)
        {
            var res = new KeyboardButton[buttons.Length % 3 == 0 ? buttons.Length / 3 : buttons.Length / 3 + 1][];
            for (int i = 0; i < buttons.Length; i++)
            {
                if(i % 3 == 0)
                {
                    res[i / 3] = new KeyboardButton[3];
                }
                res[i / 3][i % 3] = buttons[i];
            }
            return res;
        }

        public async Task Execute(Update update)
        {
            Message msg = update.Message;
            long chatId = msg.Chat.Id;
            client.SendTextMessageAsync(chatId, "");

            ContextRepository<Employee> dbEmployee = new ContextRepository<Employee>();
            ContextRepository<Patient> dbPatient = new ContextRepository<Patient>();
            ContextRepository<Appointment> dbAppointment = new ContextRepository<Appointment>();

            appointments = dbAppointment.GetTable().Where(x => x.PatientId == null).ToList();
            if (appointments.Count == 0)
            {
                await client.SendTextMessageAsync(chatId, "На данный момент нет записей!");
                Executor.StopListen();
                return;
            }

            var specializationsBtn = appointments.Select(x => dbEmployee.GetItemById(x.DoctorId).Specialization)
                                                 .ToHashSet()
                                                 .Select(x => new KeyboardButton(x))
                                                 .ToArray();

            var specializationMarkup = new ReplyKeyboardMarkup(ToRows(specializationsBtn))
            {
                ResizeKeyboard = true,
                OneTimeKeyboard = true
            };
            await client.SendTextMessageAsync(update.Message.Chat.Id, "Выеберите специальность врача (Для отмены напишите Меню)", replyMarkup: specializationMarkup);

            Executor.StartListen(this);
        }

        public async Task GetUpdate(Update update)
        {
            ContextRepository<Employee> dbEmployee = new ContextRepository<Employee>();
            ContextRepository<Patient> dbPatient = new ContextRepository<Patient>();

            if (doctorSpecialization == null)
            {
                doctorSpecialization = update.Message.Text;
                var appointmentsTmp = appointments.Where(x => dbEmployee.GetItemById(x.DoctorId).Specialization == doctorSpecialization).ToList();
                if(appointmentsTmp.Count == 0)
                {
                    await client.SendTextMessageAsync(update.Message.Chat.Id, "На данную специализацию нет записей!");
                }
                appointments = appointmentsTmp;

                var specializationBtn = appointments.Select(x => new KeyboardButton(dbEmployee.GetItemById(x.DoctorId).Surname)).ToArray();
                var specializationMarkup = new ReplyKeyboardMarkup(ToRows(specializationBtn))
                {
                    ResizeKeyboard = true,
                    OneTimeKeyboard = true
                };
                await client.SendTextMessageAsync(update.Message.Chat.Id, "Выеберите врача", replyMarkup: specializationMarkup);
            }
            else if(doctorSurname == null)
            {
                doctorSurname = update.Message.Text;

                var appointmentsTmp = appointments.Where(x => dbEmployee.GetItemById(x.DoctorId).Surname == doctorSurname).ToList();
                if (appointmentsTmp.Count == 0)
                {
                    await client.SendTextMessageAsync(update.Message.Chat.Id, "К данному врачу нет записей!");
                }
                appointments = appointmentsTmp;

                var doctorsBtn = appointments.Select(x => new KeyboardButton(x.AppointmentTime.ToString())).ToArray();
                var doctorsMarkup = new ReplyKeyboardMarkup(ToRows(doctorsBtn))
                {
                    ResizeKeyboard = true,
                    OneTimeKeyboard = true
                };
                await client.SendTextMessageAsync(update.Message.Chat.Id, "Выеберите время", replyMarkup: doctorsMarkup);
            }
            else
            {
                appointmentTime = update.Message.Text;
                Appointment? appointment = appointments.Find(x => x.AppointmentTime.ToString() == appointmentTime);
                if (appointment == null)
                {
                    await client.SendTextMessageAsync(update.Message.Chat.Id, "На данное время нет записей!");
                }
                appointment.PatientId = UserManager.GetUserByChatId(update.Message.Chat.Id).Id;
                ContextRepository<Appointment> db = new ContextRepository<Appointment>();
                await db.UpdateItemAsync(appointment);

                await client.SendTextMessageAsync(update.Message.Chat.Id, "Вы успешно записанны");
                Executor.StopListen();
            }
        }
    }
}
