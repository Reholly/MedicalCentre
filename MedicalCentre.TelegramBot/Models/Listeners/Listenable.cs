using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace MedicalCentre.TelegramBot.Models.Listeners
{
    internal class Listenable
    {
        private static IListener baseListener => new BaseListener();
        private static IListener listener = baseListener;

        public static void Notify(Update update)
        {
            listener.GetUpdate(update);
        }

        public static void StartListen(IListener newListener)
        {
            listener = newListener;
        }

        public static void StopListen()
        {
            listener = baseListener;
        }
    }
}
