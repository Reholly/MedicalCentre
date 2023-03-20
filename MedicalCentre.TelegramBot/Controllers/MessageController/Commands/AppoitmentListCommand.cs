using MedicalCentre.DatabaseLayer;
using MedicalCentre.Models;
using MedicalCentre.TelegramBot.Models;
using System.Collections;
using System.Text;
using System.Windows.Forms;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using User = MedicalCentre.TelegramBot.Models.User;

namespace MedicalCentre.TelegramBot.Controllers.MessageController.Commands
{
    internal class AppoitmentListCommand : ICommand
    {
        public string Name => "Записи";

        public TelegramBotClient client => Bot.GetTelegramBot();

        public bool NeedAutorization => true;

        public async Task Execute(Update update)
        {
            var chatId = update.Message.Chat.Id;
            ContextRepository<Appointment> dbAppointment = new ContextRepository<Appointment>();
            List<Appointment> appointments = dbAppointment.GetTableAsync().Result;

            User? user = UserManager.GetUserByChatId(chatId);

            ContextRepository<Employee> dbEmployee = new ContextRepository<Employee>();
            ContextRepository<Patient> dbPatient = new ContextRepository<Patient>();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Предстоящие записи");
            foreach(var appointment in appointments)
            {
                if (appointment.PatientId == null)
                    continue;

                if (dbPatient.GetItemById((uint)appointment.PatientId).PhoneNumber == user.PhoneNumber && !appointment.IsFinished)
                {
                    sb.AppendLine($"{appointment.AppointmentTime} - {dbEmployee.GetItemById(appointment.DoctorId).Surname} " +
                                  $"{dbEmployee.GetItemById(appointment.DoctorId).Name} " +
                                  $"({dbEmployee.GetItemById(appointment.DoctorId).Specialization})");
                }
            }

            await client.SendTextMessageAsync(chatId, sb.ToString());
            await new MenuCommand().Execute(update);
        }
    }
}
