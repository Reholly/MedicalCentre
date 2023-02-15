using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalCentre.TelegramBot.MessageController.Listeners;
using MedicalCentre.TelegramBot.Models;
using Telegram.Bot.Types;

namespace MedicalCentre.TelegramBot.MessageController
{
    internal static class MessageDistributor
    {
        private static List<BaseListener> listeners = new List<BaseListener>();

        public static void Notify(Update update)
        {
            long chatId = update.Message.Chat.Id;
            foreach (var listener in listeners)
            {
                if (chatId == listener.ChatId)
                {
                    listener.GetUpdate(update);
                    return;
                }
            }
            BaseListener newListener = new BaseListener(chatId);
            listeners.Add(newListener);
            Logger.Log("Создан новый BaseListener");
            newListener.GetUpdate(update);

        }
    }
}
