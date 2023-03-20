using MedicalCentre.TelegramBot.Models;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace MedicalCentre.TelegramBot.Controllers.MessageController.Commands
{
    internal class MenuCommand : ICommand
    {
        public string Name => "Меню";

        public TelegramBotClient client => Bot.GetTelegramBot();

        public bool NeedAutorization => false;

        public async Task Execute(Update update)
        {
            string menu = "Выберите комманду для продолжения\n\n" +
                          "Анализы - Получить информацию о результатах анализов\n\n" +
                          "Записи - Предстоящие записи\n\n" +
                          "История - История посещений\n\n" +
                          "Запись - Записаться на прием\n\n" +
                          "Инфо - общая информация о поликлинике";

            KeyboardButton[] buttons = new[]
            {
                new KeyboardButton("Анализы"),
                new KeyboardButton("Записи"),
                new KeyboardButton("История"),
                new KeyboardButton("Запись"),
                new KeyboardButton("Инфо"),
            };

            var menuMarkup = new ReplyKeyboardMarkup(buttons)
            {
                ResizeKeyboard = true,
                OneTimeKeyboard = true
            };
            await client.SendTextMessageAsync(update.Message.Chat.Id, menu, replyMarkup: menuMarkup);
        }
    }
}
