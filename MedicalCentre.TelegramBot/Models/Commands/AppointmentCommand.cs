using MedicalCentre.TelegramBot.Models.Listeners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace MedicalCentre.TelegramBot.Models.Commands
{
    internal class AppointmentCommand : Command, IListener
    {
        public override string Name => "/appointment";

        protected override TelegramBotClient client => Bot.GetTelegramBot();

        public IListenable listenable => Listenable.GetListenable();

        public override void Execute(Update update)
        {
            Message msg = update.Message;
            long chatId = msg.Chat.Id;
            //client.SendTextMessageAsync();
        }

        public void GetUpdate(Update update)
        {
            
        }
    }
}
