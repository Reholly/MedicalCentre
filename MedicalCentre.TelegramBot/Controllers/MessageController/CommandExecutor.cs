using MedicalCentre.TelegramBot.Controllers.MessageController.Commands;
using MedicalCentre.TelegramBot.Controllers.UpdateDistributor;
using MedicalCentre.TelegramBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace MedicalCentre.TelegramBot.Controllers.MessageController
{
    internal class CommandExecutor : ITelegramUpdateListener
    {
        private TelegramBotClient client => Bot.GetTelegramBot();
        private IListener? listener = null;

        public List<Command> Commands { get; }

        public CommandExecutor()
        {
            Commands = new List<Command>()
            {
                new StartCommand(),
                new RegisterCommand(this),
                new NotifateCommand(),
                new AppointmentCommand(this)
            };
        }


        public void GetUpdate(Update update)
        {
            Message msg = update.Message;
            if (msg == null)
                return;
            long chatId = msg.Chat.Id;
            Logger.Log($"Received a '{msg.Text}' message in chat {chatId}.");

            if (listener == null)
            {
                if (msg.Text != null && msg.Text.Contains("/"))
                {
                    ExecuteCommand(update);
                }
            }
            else
            {
                listener.GetUpdate(update);
            }
        }

        private void ExecuteCommand(Update update)
        {
            Message msg = update.Message;
            foreach (var command in Commands)
            {
                if (command.Name == msg.Text)
                {
                    command.Execute(update);
                    break;
                }
            }
        }



        public void StartListen(IListener newListener)
        {
            listener = newListener;
        }

        public void StopListen()
        {
            listener = null;
        }
    }
}
