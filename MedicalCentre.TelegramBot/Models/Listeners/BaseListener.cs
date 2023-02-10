using MedicalCentre.TelegramBot.Models;
using MedicalCentre.TelegramBot.Models.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace MedicalCentre.TelegramBot.Models.Listeners
{
    internal class BaseListener : IListener
    {
        private TelegramBotClient client => Bot.GetTelegramBot();

        public List<Command> Commands { get; } = new List<Command>()
            {
                new StartCommand(),
                new RegisterCommand(),
                new NotifateCommand()
            };

        public void GetUpdate(Update update)
        {
            Message msg = update.Message;
            if (msg == null)
                return;

            long chatId = msg.Chat.Id;
            if (msg.Text != null)
            {
                Logger.Log($"Received a '{msg.Text}' message in chat {chatId}.");
                if (msg.Text.Contains("/"))
                {
                    ExecuteCommand(update);
                }
            }
        }

        public void ExecuteCommand(Update update)
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
