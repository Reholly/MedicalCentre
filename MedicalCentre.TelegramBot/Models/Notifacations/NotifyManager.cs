using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using MedicalCentre.TelegramBot.Models.UserWork;

namespace MedicalCentre.TelegramBot.Models.Notifacations
{
    internal class NotifyManager
    {
        private static TelegramBotClient client = Bot.GetTelegramBot();

        public static void SendNotifyAllUsers()
        {
            Logger.Log("Notification sended to all users");
            List<User> users = UsersManager.Users;
            foreach (User user in users)
            {
                client.SendTextMessageAsync(user.ChatId, "Уведомляю, что тебе пришло уведомление об уведомлении!");
            }
        }
    }
}
