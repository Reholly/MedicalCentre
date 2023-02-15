using MedicalCentre.TelegramBot.MessageController.Listeners;
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

        protected override TelegramBotClient client => Bot.GetTelegramBot();

        public override void Execute(Update update, BaseListener listener)
        {
            Message msg = update.Message;
            long chatId = msg.Chat.Id;
            //client.SendTextMessageAsync();
        }

        public void GetUpdate(Update update, BaseListener listener)
        {

        }
    }
}
