using MedicalCentre.TelegramBot.Models;
using MedicalCentre.TelegramBot.Models.Listeners;
using MedicalCentre.TelegramBot.Models.Notifacations;
using MedicalCentre.TelegramBot.Models.UserWork;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace MedicalCentre.TelegramBot
{
    internal class Program
    { 

        public static async Task Main(string[] args)
        {
            TelegramBotClient client = Bot.GetTelegramBot();
            client.StartReceiving(Update, Error);

            var me = await client.GetMeAsync();
            Logger.Log("Bot was started");
            Logger.Log($"Start listening for @{me.Username}");

            var nTimer = new TimerNotification(AppSetings.TimeOfNotification);
            nTimer.StartTimer();

            Console.ReadKey();
        }

        private async static Task Update(ITelegramBotClient client, Update update, CancellationToken token)
        {
            Listenable.Notify(update);
        }

        private async static Task Error(ITelegramBotClient botClient, Exception exception, CancellationToken token)
        {
            Logger.Log($"Error: {exception.Message}");
        }
    }
}