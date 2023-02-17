using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using MedicalCentre.TelegramBot.Models;
using MedicalCentre.TelegramBot.DataBaseLayer;

namespace MedicalCentre.TelegramBot.Notifacations
{
    internal class Notifayer
    {
        private TelegramBotClient client = Bot.GetTelegramBot();
        private DateOnly date;
            
        public Notifayer(DateOnly date) 
        {
            this.date = date;
        }

        public void SendAllNotifacates()
        {
            Logger.Log("Notification sended to all users");

            List<User> users = DatabaseTelegram.Users;
            foreach (User user in users)
            {
                client.SendTextMessageAsync(user.ChatId, "Уведомляю, что тебе пришло уведомление об уведомлении!");
            }
        }
    }
}
