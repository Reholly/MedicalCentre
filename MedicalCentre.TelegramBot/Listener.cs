using MedicalCentre.TelegramBot.Models.Commands;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace MedicalCentre.TelegramBot
{
    internal class Listener
    {
        private static IListener listener;

        public static void Update(Update update)
        {
            if (listener != null)
            {
                listener.GetUpdate(update);
            }
        }

        public static void StartListen(IListener newListener)
        {
            if (listener != null)
                throw new Exception("Listener already exist!");

            listener = newListener;
        }

        public static void StopListen()
        {
            listener = null;
        }
    }
}
