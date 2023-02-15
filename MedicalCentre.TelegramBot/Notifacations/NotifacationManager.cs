using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using MedicalCentre.TelegramBot.Models;

namespace MedicalCentre.TelegramBot.Notifacations
{
    internal class NotifacationManager
    {
        private static TelegramBotClient client = Bot.GetTelegramBot();
        public static void SendAllNotifacate()
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
