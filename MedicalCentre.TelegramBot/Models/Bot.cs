using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace MedicalCentre.TelegramBot.Models
{
    internal class Bot
    {
        private static TelegramBotClient client { get; set; }

        public static TelegramBotClient GetTelegramBot()
        {
            if(client != null)
            {
                return client;
            }
            client = new TelegramBotClient(AppSetings.Token);
            return client;
        }
    }
}
