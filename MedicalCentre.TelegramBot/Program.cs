using MedicalCentre.TelegramBot.Models;
using MedicalCentre.TelegramBot.Models.Commands;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using User = MedicalCentre.TelegramBot.Models.User;

namespace MedicalCentre.TelegramBot
{
    internal class Program
    { 
        
        public static async Task Main(string[] args)
        {
            Logger.Log("Bot was started");
            TelegramBotClient client = Bot.GetTelegramBot();
            client.StartReceiving(Update, Error);
            var me = await client.GetMeAsync();
            Logger.Log($"Start listening for @{me.Username}");
            Console.ReadLine();
        }

        private async static Task Update(ITelegramBotClient client, Update update, CancellationToken token)
        {
            Message msg = update.Message;
            long chatId = msg.Chat.Id;
            if (msg == null)
            {
                return;
            }

            if (msg.Text != null)
            {
                Logger.Log($"Received a '{msg.Text}' message in chat {chatId}.");
                if (msg.Text.Contains("/"))
                {
                    CommandManager.ExecuteCommand(client, update);
                }
            }      
            
            if (msg.Type == MessageType.Contact && msg.Contact != null)
            {
                if(UsersManager.TryRegisterUser(chatId, msg.Contact.FirstName, msg.Contact.PhoneNumber))
                {
                    client.SendTextMessageAsync(chatId, "Поздравляем с регистрацией!");
                }
                else
                {
                    client.SendTextMessageAsync(chatId, "Вы уже зарегистрированны!");
                }
            }
        }

        private async static Task Error(ITelegramBotClient botClient, Exception exception, CancellationToken token)
        {
            Logger.Log($"Error: {exception.Message}");
        }
    }
}