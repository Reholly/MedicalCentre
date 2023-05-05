using MedicalCentre.TelegramBot.Models;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace MedicalCentre.TelegramBot.Controllers.MessageController.Commands
{
    internal class StartCommand : ICommand
    {
        private string hello = "Для начала работы зарегестрируйтесь или авторизуйтесь!";

        public TelegramBotClient client => Bot.GetTelegramBot();

        public bool NeedAutorization => false;

        public string Name => "/start";

        public async Task Execute(Update update)
        {
            KeyboardButton regsterBtn = new KeyboardButton("Регистрация");
            var regsterMarkup = new ReplyKeyboardMarkup(regsterBtn)
            {
                ResizeKeyboard = true, 
                OneTimeKeyboard = true 
            };
            await client.SendTextMessageAsync(update.Message.Chat.Id, hello, replyMarkup: regsterMarkup);
        }
    }
}
