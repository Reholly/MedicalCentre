using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace MedicalCentre.TelegramBot.Models.Commands
{
    abstract class Command
    {
        public abstract string Name { get; }
        public abstract void Execute(ITelegramBotClient client, Update update);
    }
}
