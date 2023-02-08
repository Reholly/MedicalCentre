using MedicalCentre.TelegramBot.Models;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;


namespace MedicalCentre.TelegramBot
{
    internal class Program
    { 

        public static async Task Main(string[] args)
        {
            Logger.Log("Bot was started");
            TelegramBotClient client = new TelegramBotClient(AppSetings.Token);
            client.StartReceiving(Update, Error);
            var me = await client.GetMeAsync();
            Logger.Log($"Start listening for @{me.Username}");
            Console.ReadLine();

        }

        private async static Task Update(ITelegramBotClient client, Update update, CancellationToken token)
        {
            var msg = update.Message;
            var chatId = msg.Chat.Id;
            if (msg == null)
                return;

            Logger.Log($"Received a '{msg.Text}' message in chat {chatId}.");
            if(msg.Text.Contains("/"))
            {
                CommandManager.ExecuteCommand(client, update);
            }
        }

        private async static Task Error(ITelegramBotClient botClient, Exception update, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}