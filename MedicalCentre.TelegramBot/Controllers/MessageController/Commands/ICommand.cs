using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace MedicalCentre.TelegramBot.Controllers.MessageController.Commands
{
    public interface ICommand
    {
        public TelegramBotClient client { get; }

        public string Name { get; }

        public bool NeedAutorization { get; }

        public async Task Execute(Update update) { }
    }
}
