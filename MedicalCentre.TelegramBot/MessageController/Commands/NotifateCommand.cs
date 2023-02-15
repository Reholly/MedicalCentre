using MedicalCentre.DatabaseLayer;
using MedicalCentre.Models;
using MedicalCentre.TelegramBot.DataBaseLayer;
using MedicalCentre.TelegramBot.MessageController.Listeners;
using MedicalCentre.TelegramBot.Models;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;
using User = MedicalCentre.TelegramBot.Models.User;

namespace MedicalCentre.TelegramBot.MessageController.Commands
{
    internal class NotifateCommand : Command
    {
        public override string Name => "/notifacate";

        protected override TelegramBotClient client => Bot.GetTelegramBot();

        public override void Execute(Update update, BaseListener listener)
        {
            var chatId = update.Message.Chat.Id;

        }
    }
}
