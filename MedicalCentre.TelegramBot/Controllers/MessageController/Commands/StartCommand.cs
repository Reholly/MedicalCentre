using MedicalCentre.TelegramBot.Models;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace MedicalCentre.TelegramBot.Controllers.MessageController.Commands
{
    internal class StartCommand : Command
    {
        private string hello = "Вас приветствует Medical Centre Bot!\n" +
                               "Для начала работы зарегестрируйтесь или авторизуйтесь!";

        protected override TelegramBotClient client => Bot.GetTelegramBot();

        public override string Name => "/start";

        public override void Execute(Update update)
        {
            KeyboardButton regsterBtn = new KeyboardButton("Регистрация");
            var regsterMarkup = new ReplyKeyboardMarkup(regsterBtn)
            {
                ResizeKeyboard = true, 
                OneTimeKeyboard = true 
            };
            client.SendTextMessageAsync(update.Message.Chat.Id, hello, replyMarkup: regsterMarkup);
        }
    }
}
