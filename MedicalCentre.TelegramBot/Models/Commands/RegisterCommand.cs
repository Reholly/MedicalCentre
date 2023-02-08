using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bots.Http;


namespace MedicalCentre.TelegramBot.Models.Commands
{
    internal class RegisterCommand : Command
    {
        protected override TelegramBotClient client => Bot.GetTelegramBot();

        public override string Name => "/register";

        public override void Execute(Update update)
        {
            long chatId = update.Message.Chat.Id;
            RequestContactAndLocation(chatId, client);
        }

        private static async Task<Message> RequestContactAndLocation(long chatId, TelegramBotClient client)
        {
            ReplyKeyboardMarkup requestReplyKeyboard = new(
               new[]
               {
                KeyboardButton.WithRequestContact("Отправить мой телефон"),
               });

            return await client.SendTextMessageAsync(chatId: chatId,
                                                        text: "Для регистрации укажите свой номер",
                                                        replyMarkup: requestReplyKeyboard);
        }
    }
}
