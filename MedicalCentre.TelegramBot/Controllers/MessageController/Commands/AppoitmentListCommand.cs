using MedicalCentre.DatabaseLayer;
using MedicalCentre.Models;
using MedicalCentre.TelegramBot.DataBaseLayer;
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
    internal class AppoitmentListCommand : Command
    {
        public override string Name => "Записи";

        protected override TelegramBotClient client => Bot.GetTelegramBot();

        public override void Execute(Update update)
        {
            var chatId = update.Message.Chat.Id;
            Database<Appointment> dbAppointment = new Database<Appointment>();
            List<Appointment> appointments = dbAppointment.GetTable();

            User? user = DatabaseTelegram.Users.Find(x => x.ChatId == chatId);
            if(user == null)
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

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Предстоящие записи");
            foreach(var appointment in appointments)
            {
                if (appointment.Patient.PhoneNumber == user.PhoneNumber && !appointment.IsFinished)
                {
                    sb.AppendLine($"{appointment.AppointmentTime} - {appointment.Doctor.Surname} {appointment.Doctor.Name} ({appointment.Doctor.Specialization})");
                }
            }

            client.SendTextMessageAsync(chatId, sb.ToString());
        }
    }
}
