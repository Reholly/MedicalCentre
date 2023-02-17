using MedicalCentre.TelegramBot.MessageController;
using MedicalCentre.TelegramBot.Models;
using MedicalCentre.TelegramBot.Notifacations;
using MedicalCentre.TelegramBot.UpdateDistributor;
using Telegram.Bot;
using Telegram.Bot.Types;
using User = MedicalCentre.TelegramBot.Models.User;

namespace MedicalCentre.TelegramBot
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            TelegramBotClient client = Bot.GetTelegramBot();

            var distributor = new UpdateDistributor<CommandExecutor>(client);
            distributor.StartReceiving();

            var nTimer = new TimerNotification(AppSetings.TimeOfNotification);
            nTimer.StartTimer();

            Console.ReadKey();
        }
    }
}