using MedicalCentre.TelegramBot.Models;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace MedicalCentre.TelegramBot.Controllers.MessageController.Commands
{
    public class InfoCommand : ICommand
    {
        public string Name => "Инфо";

        public TelegramBotClient client => Bot.GetTelegramBot();

        public bool NeedAutorization => false;

        public async Task Execute(Update update)
        {
            string info = "ООО \"Медицинский центр\"\n" +
                          "Адрес: г. Мозырь, улица Кирсанова, дом 312\n" +
                          "Номер: 8 800 555 3535";
            await client.SendTextMessageAsync(update.Message.Chat.Id, info);
            await new MenuCommand().Execute(update);
        }
    }
}
