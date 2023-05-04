using MedicalCentre.DatabaseLayer;
using MedicalCentre.Models;
using MedicalCentre.TelegramBot.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

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

        public async Task Execute(Update update)
        {
            Message msg = update.Message;
            long chatId = msg.Chat.Id;
            ContextRepository<Employee> dbEmployee = new ContextRepository<Employee>();
            ContextRepository<Patient> dbPatient = new ContextRepository<Patient>();
            ContextRepository<Appointment> dbAppointment = new ContextRepository<Appointment>();

            appointments = dbAppointment.GetTable().Where(x => x.PatientId == null && x.AppointmentTime > DateTime.Now).ToList();
            if (appointments.Count == 0)
            {
                await client.SendTextMessageAsync(chatId, "На данный момент нет записей!");
                Executor.StopListen();
                return;
            }

            var specializationsBtn = appointments.Select(x => dbEmployee.GetItemById(x.DoctorId).Specialization)
                                                 .Distinct()
                                                 .Select(x => new KeyboardButton(x))
                                                 .ToArray();
            if(specializationsBtn == null) //Возможно, если в БД лежит прием к несуществующему врачу
            {
                await client.SendTextMessageAsync(chatId, "Винтовка это праздник! Все летит не по плану");
                await new MenuCommand().Execute(update);
                return;
            }

            var specializationMarkup = new ReplyKeyboardMarkup(specializationsBtn.AddBackButton().ToRows(3))
            {
                ResizeKeyboard = true,
                OneTimeKeyboard = true
            };
            await client.SendTextMessageAsync(update.Message.Chat.Id, "Выеберите специальность врача", replyMarkup: specializationMarkup);
            Executor.StartListen(this);
        }

        public async Task GetUpdate(Update update)
        {
            ContextRepository<Employee> dbEmployee = new ContextRepository<Employee>();
            ContextRepository<Patient> dbPatient = new ContextRepository<Patient>();

            if (doctorSpecialization == null)
            {
                if(update.Message.Text == "Назад")
                {
                    Executor.StopListen();
                    await new MenuCommand().Execute(update);
                    return;
                }
                await GetSpecialization(update, dbEmployee);
            }
            else if(doctorSurname == null)
            {
                if (update.Message.Text == "Назад")
                {
                    doctorSpecialization = null;
                    await Execute(update);
                    return;
                }
                await GetDoctor(update, dbEmployee);
            }
            else
            {
                if (update.Message.Text == "Назад")
                {
                    doctorSurname = null;
                    await Execute(update);
                    return;
                }
                await GetTime(update);
            }
        }

        private async Task GetTime(Update update)
        {
            appointmentTime = update.Message.Text;
            Appointment? appointment = appointments.Find(x => x.AppointmentTime.ToString() == appointmentTime);
            if (appointment == null)
            {
                appointmentTime = null;
                await client.SendTextMessageAsync(update.Message.Chat.Id, "На данное время нет записи!");
                await Execute(update);
                return;
            }
            appointment.PatientId = UserManager.GetUserByChatId(update.Message.Chat.Id).Id;
            ContextRepository<Appointment> db = new ContextRepository<Appointment>();
            await db.UpdateItemAsync(appointment);

            await client.SendTextMessageAsync(update.Message.Chat.Id, "Вы успешно записанны");
            doctorSpecialization = null;
            doctorSurname = null;
            appointmentTime = null;
            Executor.StopListen();
            new MenuCommand().Execute(update);
        }

        private async Task GetDoctor(Update update, ContextRepository<Employee> dbEmployee)
        {
            doctorSurname = update.Message.Text;

            var appointmentsTmp = appointments.Where(x => dbEmployee.GetItemById(x.DoctorId).Surname == doctorSurname).ToList();
            if (appointmentsTmp.Count == 0)
            {
                doctorSurname = null;
                await client.SendTextMessageAsync(update.Message.Chat.Id, "К данному врачу нет записей!");
                await Execute(update);
                return;
            }
            appointments = appointmentsTmp;

            var doctorsBtn = appointments.Select(x => x.AppointmentTime.ToString())
                                         .Distinct()
                                         .Select(x => new KeyboardButton(x))
                                         .ToArray();
            var doctorsMarkup = new ReplyKeyboardMarkup(doctorsBtn.AddBackButton().ToRows(3))
            {
                ResizeKeyboard = true,
                OneTimeKeyboard = true
            };
            await client.SendTextMessageAsync(update.Message.Chat.Id, "Выеберите время", replyMarkup: doctorsMarkup);
        }

        private async Task GetSpecialization(Update update, ContextRepository<Employee> dbEmployee)
        {
            doctorSpecialization = update.Message.Text;
            var appointmentsTmp = appointments.Where(x => dbEmployee.GetItemById(x.DoctorId).Specialization == doctorSpecialization).ToList();
            if (appointmentsTmp.Count == 0)
            {
                doctorSpecialization= null;
                await client.SendTextMessageAsync(update.Message.Chat.Id, "На данную специализацию нет записей!");
                await Execute(update);
                return;
            }
            appointments = appointmentsTmp;

            var specializationBtn = appointments.Select(x => dbEmployee.GetItemById(x.DoctorId).Surname)
                                                .Distinct()
                                                .Select(x => new KeyboardButton(x))
                                                .ToArray();
            var specializationMarkup = new ReplyKeyboardMarkup(specializationBtn.AddBackButton().ToRows(3))
            {
                ResizeKeyboard = true,
                OneTimeKeyboard = true
            };
            await client.SendTextMessageAsync(update.Message.Chat.Id, "Выеберите врача", replyMarkup: specializationMarkup);
        }
    }
}
