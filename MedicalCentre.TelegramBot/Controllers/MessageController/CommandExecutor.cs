using MedicalCentre.TelegramBot.Controllers.MessageController.Commands;
using MedicalCentre.TelegramBot.Controllers.UpdateDistributor;
using MedicalCentre.TelegramBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Requests.Abstractions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using User = MedicalCentre.TelegramBot.Models.User;

namespace MedicalCentre.TelegramBot.Controllers.MessageController
{
    internal class CommandExecutor : ITelegramUpdateListener
    {
        private TelegramBotClient client => Bot.GetTelegramBot();
        private IListener? listener = null;
        private User? user = null;
        public List<ICommand> Commands { get; }

        private List<ICommand> GetCommands()
        {
            var types = AppDomain
                      .CurrentDomain
                      .GetAssemblies()
                      .SelectMany(assembly => assembly.GetTypes())
                      .Where(type => typeof(ICommand).IsAssignableFrom(type))
                      .Where(type => type.IsClass);

            List<ICommand> commands = new List<ICommand>();
            foreach(var type in types)
            {
                ICommand? command;
                if(typeof(IListener).IsAssignableFrom(type))
                {
                    command = Activator.CreateInstance(type, this) as ICommand;
                }
                else
                {
                    command = Activator.CreateInstance(type) as ICommand;
                }

                if(command != null)
                {
                    commands.Add(command);
                }
            }
            return commands;
        }

        public CommandExecutor()
        {
            Commands = GetCommands();
        }

        public async Task GetUpdate(Update update)
        {
            Message? msg = update.Message;
            if (msg == null)
                return;

            long chatId = msg.Chat.Id;
            Logger.Log($"Received a '{msg.Text}' message in chat {chatId}.");

            if (listener == null)
            {
                foreach (var command in Commands)
                {
                    if (command.Name == msg.Text)
                    {
                        if(command.NeedAutorization && user == null)
                        {
                            await new StartCommand().Execute(update);
                        }
                        else
                        {
                            await command.Execute(update);
                        }
                        return;
                    }
                }
            }
            else
            {
                await listener.GetUpdate(update);
            }
        }

        public void UpdateUser(long chatId)
        {
            user = UserManager.GetUserByChatId(chatId);
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
