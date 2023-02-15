using MedicalCentre.TelegramBot.MessageController.Commands;
using MedicalCentre.TelegramBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace MedicalCentre.TelegramBot.MessageController.Listeners
{
    internal class BaseListener
    {
        private TelegramBotClient client => Bot.GetTelegramBot();
        private IListener? listener = null;

        public List<Command> Commands { get; } 

        public long ChatId { get; }

        public BaseListener(long chatId)
        {
            Commands = new List<Command>()
            {
                new StartCommand(),
                new RegisterCommand(),
                new NotifateCommand(),
                new AppointmentCommand()
            };
            ChatId = chatId;
        }

        public void GetUpdate(Update update)
        {
            Message msg = update.Message;
            if (msg == null)
                return;
            Logger.Log($"Received a '{msg.Text}' message in chat {ChatId}.");


            if(listener == null)
            {
                Logger.Log($"Слушателя нет, сообщение отработал BaseListener({ChatId})");
                if (msg.Text != null && msg.Text.Contains("/"))
                {
                    ExecuteCommand(update);
                }
            }
            else
            {
                Logger.Log($"Сообщение передано слушателю");
                listener.GetUpdate(update, this);
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
        public void ExecuteCommand(Update update)
        {
            Message msg = update.Message;
            foreach (var command in Commands)
            {
                if (command.Name == msg.Text)
                {
                    command.Execute(update, this);
                    break;
                }
            }
        }

    }
}
