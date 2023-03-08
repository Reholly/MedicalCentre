using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalCentre.TelegramBot.Models;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace MedicalCentre.TelegramBot.Controllers.UpdateDistributor
{
    internal class UpdateDistributor<T> where T : ITelegramUpdateListener, new()
    {
        private Dictionary<long, T> listeners;

        public UpdateDistributor(TelegramBotClient client)
        {
            listeners = new Dictionary<long, T>();
        }

        public void Update(Update update)
        {
            long chatId = update.Message.Chat.Id;
            foreach (var listener in listeners)
            {
                if (chatId == listener.Key)
                {
                    listener.Value.GetUpdate(update);
                    return;
                }
            }
            T newListener = new T();
            listeners.Add(chatId, newListener);
            newListener.GetUpdate(update);
        }
    }
}
