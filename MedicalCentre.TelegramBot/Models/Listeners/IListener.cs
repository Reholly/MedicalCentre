using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace MedicalCentre.TelegramBot.Models.Listeners
{
    internal interface IListener
    {
        public void GetUpdate(Update update);
    }
}
