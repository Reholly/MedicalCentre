using Telegram.Bot;
using Telegram.Bot.Types;

namespace MedicalCentre.TelegramBot.Models.Commands
{
    internal class StartCommand : Command
    {
        public override string Name => "/start";

        public override void Execute(ITelegramBotClient client, Update update)
        {
            client.SendTextMessageAsync(update.Message.Chat.Id, "Вас приветствует Medical Centre Bot! На ротан дать?");
        }
    }
}
