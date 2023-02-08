using MedicalCentre.TelegramBot.Models;
using MedicalCentre.TelegramBot.Models.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace MedicalCentre.TelegramBot
{
    internal static class CommandManager
    {
        public static List<Command> Commands { get; } = new List<Command>()
            {
                new StartCommand(),
                new RegisterCommand()
            };

        public static void ExecuteCommand(ITelegramBotClient client, Update update)
        {
            Message msg = update.Message;
            foreach (var command in Commands)
            {
                if (command.Name == msg.Text)
                {
                    command.Execute(update);
                }
            }
        }
    }
}
