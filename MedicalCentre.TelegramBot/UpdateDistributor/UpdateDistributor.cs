using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalCentre.TelegramBot.Models;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace MedicalCentre.TelegramBot.UpdateDistributor
{
    /*
     * Распределяет все апдейты от телеграма по экземплярам T,
     * уникальным для каждого пользователя
     */
    internal class UpdateDistributor<T> where T : ITelegramUpdateListener, new()
    {
        private Dictionary<long, T> listeners;
        private TelegramBotClient client;
        public UpdateDistributor(TelegramBotClient client)
        {
            listeners = new Dictionary<long, T>();
            this.client = client;
        }

        public void StartReceiving()
        {
            client.StartReceiving(Update, Error);
            Logger.Log("Bot was started");
        }

        private async Task Update(ITelegramBotClient client, Update update, CancellationToken token)
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

        private async static Task Error(ITelegramBotClient botClient, Exception exception, CancellationToken token)
        {
            Logger.Log($"Error: {exception.Message}");
        }
    }
}
