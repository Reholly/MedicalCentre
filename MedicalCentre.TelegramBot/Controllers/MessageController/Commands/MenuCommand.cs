using MedicalCentre.TelegramBot.Models;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace MedicalCentre.TelegramBot.Controllers.MessageController.Commands
{
    internal class MenuCommand : Command
    {
        public override string Name => "Меню";

        protected override TelegramBotClient client => Bot.GetTelegramBot();

        public override void Execute(Update update)
        {
            string menu = "Выберите комманду для продолжения\n\n" +
                          "Мои записи - Получить информацию о записях/результатах анализов\n\n" +
                          "Запись - Записаться на прием\n\n" +
                          "Инфо - общая информация о поликлинике";

            KeyboardButton notifyBtn = new KeyboardButton("Мои записи");
            KeyboardButton appoitmentBtn = new KeyboardButton("Запись");
            KeyboardButton infoBtn = new KeyboardButton("Инфо");
            var menuMarkup = new ReplyKeyboardMarkup(new[] { notifyBtn, appoitmentBtn, infoBtn })
            {
                ResizeKeyboard = true,
                OneTimeKeyboard = true
            };
            client.SendTextMessageAsync(update.Message.Chat.Id, menu, replyMarkup: menuMarkup);
        }
    }
}
