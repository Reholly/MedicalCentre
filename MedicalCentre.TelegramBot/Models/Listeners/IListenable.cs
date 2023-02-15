using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace MedicalCentre.TelegramBot.Models.Listeners
{
    internal interface IListenable
    {
        public void Notify(Update update);
        public void StartListen(IListener newListener);
        public void StopListen();
    }
}
