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

        public UpdateDistributor()
        {
            listeners = new Dictionary<long, T>();
        }

        public async Task Update(Update update)
        {
            long chatId = update.Message.Chat.Id;
            T? listener = listeners.GetValueOrDefault(chatId);
            if (listener is null)
            {
                listener = new T();
                listeners.Add(chatId, listener);
                await listener.GetUpdate(update);
                return;
            }
            await listener.GetUpdate(update);
        }
    }
}
