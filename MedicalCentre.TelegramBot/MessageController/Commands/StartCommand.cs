using MedicalCentre.TelegramBot.MessageController.Listeners;
using MedicalCentre.TelegramBot.Models;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace MedicalCentre.TelegramBot.MessageController.Commands
{
    internal class StartCommand : Command
    {
        protected override TelegramBotClient client => Bot.GetTelegramBot();

        public override string Name => "/start";

        public override void Execute(Update update, BaseListener listener)
        {
            client.SendTextMessageAsync(update.Message.Chat.Id, "Вас приветствует Medical Centre Bot! На ротан дать?");
        }
    }
}
