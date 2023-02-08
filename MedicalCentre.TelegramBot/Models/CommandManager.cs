using MedicalCentre.TelegramBot.Models.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace MedicalCentre.TelegramBot.Models
{
    internal class CommandManager
    {
        private static List<Command> commands = new List<Command>()
        {
            new StartCommand(),
            new RegisterCommand()
        };

        public static bool ExecuteCommand(ITelegramBotClient client, Update update)
        {
            string input_command = update.Message.Text;
            foreach (var command in commands)
            {
                if(command.Name == input_command)
                {
                    command.Execute(client, update);
                    return true;
                }
            }
            return false;
        }
    }
}
