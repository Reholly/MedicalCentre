using MedicalCentre.Models;
using MedicalCentre.TelegramBot.DataBaseLayer;
using MedicalCentre.TelegramBot.Models;
using System;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace MedicalCentre.TelegramBot.Controllers.MessageController.Commands
{
    internal class RegisterCommand : Command, IListener
    {
        protected override TelegramBotClient client => Bot.GetTelegramBot();

        private string? phone = null;
        private string? name = null;
        private string? surname = null;
        private string? lastname = null;
        private DateOnly? birthDate = null;


        public override string Name => "Регистрация";

        public CommandExecutor Executor { get; }

        public RegisterCommand(CommandExecutor executor)
        {
            Executor = executor;
        }
        public override void Execute(Update update)
        {
            long chatId = update.Message.Chat.Id;
            Executor.StartListen(this);
            RequestContact(chatId);
        }

        public void GetUpdate(Update update)
        {
            Message msg = update.Message;
            long chatId = msg.Chat.Id;

            if (phone == null)
            {
                if (msg.Type == MessageType.Contact && msg.Contact != null)
                {
                    phone = msg.Contact.PhoneNumber;
                    DatabaseTelegram db = new DatabaseTelegram();
                    Patient? patient = db.patients.Find(patient => patient.PhoneNumber == phone);
                    if (patient != null)
                    {
                        client.SendTextMessageAsync(chatId, "Вы уже зарегестрированы!");
                        db.AutorizeUser(new Models.User(chatId, patient));
                        ShowMenuBtn(chatId);
                        Executor.StopListen();
                        return;
                    }
                    client.SendTextMessageAsync(chatId, "Укажите ваши ФИО в формате \"Иванов Иван Иванович\"");
                }
                else
                {
                    client.SendTextMessageAsync(chatId, "Отправьте контактом!");
                }
            }
            else if (name == null || surname == null || lastname == null)
            {
                string[] input = msg.Text.Split(" ");
                if (input.Length == 3)
                {
                    surname = input[0];
                    name = input[1];
                    lastname = input[2];
                    client.SendTextMessageAsync(chatId, $"Укажите вашу дату рождения в формате \"{DateTime.Now.ToShortDateString()}\"");
                }
                else
                {
                    client.SendTextMessageAsync(chatId, "Невреный формат!");
                }
            }
            else if (birthDate == null)
            {
                try
                {
                    birthDate = DateOnly.Parse(msg.Text);
                }
                catch
                {
                    client.SendTextMessageAsync(chatId, "Невреный формат!");
                    return;
                }

                Patient patient = new Patient()
                {
                    PhoneNumber = phone,
                    Name = name,
                    Surname = surname,
                    Patronymic = lastname,
                    BirthDate = (DateOnly)birthDate
                };

                DatabaseTelegram db = new DatabaseTelegram();
                db.RegisterUser(new Models.User(chatId, patient));
                client.SendTextMessageAsync(chatId, "Вы успешно зарегестрированны!");
                ShowMenuBtn(chatId);

                Logger.Log($"{patient.Name} registered by phone({patient.PhoneNumber}) in chat {chatId}");
                Executor.StopListen();
            }
        }

        private void ShowMenuBtn(long chatId)
        {
            KeyboardButton menuBtn = new KeyboardButton("Меню");
            var menuMarkup = new ReplyKeyboardMarkup(menuBtn)
            {
                ResizeKeyboard = true,
                OneTimeKeyboard = true
            };
            client.SendTextMessageAsync(chatId, "Вы можете ознакомиться с фкнкциями бота в меню", replyMarkup: menuMarkup);
        }

        private void RequestContact(long chatId)
        {
            KeyboardButton requestContactBtn = KeyboardButton.WithRequestContact("Отправить мой телефон");
            var equestContactMarkup = new ReplyKeyboardMarkup(requestContactBtn)
            {
                ResizeKeyboard = true,
                OneTimeKeyboard = true
            };
            client.SendTextMessageAsync(chatId, "Для регистрации укажите свой номер", replyMarkup: equestContactMarkup);
        }
    }
}
