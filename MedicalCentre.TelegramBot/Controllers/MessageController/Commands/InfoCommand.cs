using MedicalCentre.TelegramBot.Models;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace MedicalCentre.TelegramBot.Controllers.MessageController.Commands
{
    internal class InfoCommand : Command
    {
        public override string Name => "Инфо";

        protected override TelegramBotClient client => Bot.GetTelegramBot();

        public override void Execute(Update update)
        {
            string info = "ООО \"Медицинский центр\"\n" +
                          "Адрес: г. Мозырь, улица Кирсанова, дом 312\n" +
                          "Номер: 8 800 555 3535";
            client.SendTextMessageAsync(update.Message.Chat.Id, info);
        }
    }
}
