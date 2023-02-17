using MedicalCentre.TelegramBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace MedicalCentre.TelegramBot.MessageController.Commands
{
    internal class AppointmentCommand : Command, IListener
    {
        public override string Name => "/appointment";

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
            //client.SendTextMessageAsync();
        }

        public void GetUpdate(Update update, CommandExecutor listener)
        {

        }

        public void GetUpdate(Update update)
        {
            throw new NotImplementedException();
        }
    }
}
