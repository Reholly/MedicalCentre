using MedicalCentre.TelegramBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace MedicalCentre.TelegramBot.Controllers.MessageController.Commands
{
    internal class AppointmentCommand : Command, IListener
    {
        public override string Name => "Запись";

        public CommandExecutor Executor { get; }

        protected override TelegramBotClient client => Bot.GetTelegramBot();

        public AppointmentCommand(CommandExecutor executor)
        {
            Executor = executor;
        }

        public override void Execute(Update update)
        {
            Message msg = update.Message;
            long chatId = msg.Chat.Id;
            client.SendTextMessageAsync(chatId, "");
        }

        public void GetUpdate(Update update)
        {
            throw new NotImplementedException();
        }
    }
}
