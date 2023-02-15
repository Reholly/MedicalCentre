using MedicalCentre.TelegramBot.MessageController.Listeners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace MedicalCentre.TelegramBot.MessageController.Commands
{
    abstract class Command
    {
        protected abstract TelegramBotClient client { get; }

        public abstract string Name { get; }

        public abstract void Execute(Update update, BaseListener baseListener);
    }


}
