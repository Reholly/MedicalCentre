using MedicalCentre.TelegramBot.Models.UserWork;
using System;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace MedicalCentre.TelegramBot.Models.Commands
{
    internal class RegisterCommand : Command, IListener
    {
        protected override TelegramBotClient client => Bot.GetTelegramBot();

        public override string Name => "/register";

        public override void Execute(Update update)
        {
            long chatId = update.Message.Chat.Id;
            Listener.StartListen(this);
            RequestContact(chatId, client);
        }

        public void GetUpdate(Update update)
        {
            Message msg = update.Message;
            long chatId = msg.Chat.Id;
            if (msg.Type == MessageType.Contact && msg.Contact != null)
            {
                if (UsersManager.TryRegisterUser(chatId, msg.Contact.FirstName, msg.Contact.PhoneNumber))
                {
                    client.SendTextMessageAsync(chatId, "Поздравляем с регистрацией!");
                }
                else
                {
                    client.SendTextMessageAsync(chatId, "Вы уже зарегистрированны!");
                }
                Listener.StopListen();
            }
        }

        private static async Task<Message> RequestContact(long chatId, TelegramBotClient client)
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
