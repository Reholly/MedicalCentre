using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace MedicalCentre.TelegramBot.Controllers.MessageController
{
    internal interface IListener
    {
        public void GetUpdate(Update update);

        public CommandExecutor Executor { get; }
    }
}
