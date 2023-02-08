using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace MedicalCentre.TelegramBot.Models.Commands
{
    internal class RegisterCommand : Command
    {
        public override string Name => "/register";

        public override void Execute(ITelegramBotClient client, Update update)
        {
            
        }
    }
}
