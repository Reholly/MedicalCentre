using MedicalCentre.DatabaseLayer;
using MedicalCentre.Models;
using MedicalCentre.TelegramBot.Models;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using User = MedicalCentre.TelegramBot.Models.User;

namespace MedicalCentre.TelegramBot.Controllers.MessageController.Commands
{
    internal class RegisterCommand : ICommand, IListener
    {
        public TelegramBotClient client => Bot.GetTelegramBot();

        private string? phone = null;
        private string? name = null;
        private string? surname = null;
        private string? lastname = null;
        private DateOnly? birthDate = null;

        public string Name => "Регистрация";

        public bool NeedAutorization => false;

        public CommandExecutor Executor { get; }

        public RegisterCommand(CommandExecutor executor)
        {
            Executor = executor;
        }

        public async Task Execute(Update update)
        {
            long chatId = update.Message.Chat.Id;
            Executor.StartListen(this);

            KeyboardButton requestContactBtn = KeyboardButton.WithRequestContact("Отправить мой телефон");
            var equestContactMarkup = new ReplyKeyboardMarkup(requestContactBtn)
            {
                ResizeKeyboard = true,
                OneTimeKeyboard = true
            };
            await client.SendTextMessageAsync(chatId, "Для регистрации укажите свой номер", replyMarkup: equestContactMarkup);
        }

        public async Task GetUpdate(Update update)
        {
            Message msg = update.Message;
            long chatId = msg.Chat.Id;

            if (phone == null)
            {
                await GetPhone(msg, chatId);
            }
            else if (name == null || surname == null || lastname == null)
            {
                if(msg.Text == null)
                    return;

                await GetFullName(msg, chatId);
            }
            else if (birthDate == null)
            {
                if (msg.Text == null)
                    return;

                await GetBirthDate(msg, chatId);
            }
        }

        private async Task GetBirthDate(Message msg, long chatId)
        {
            try
            {
                birthDate = DateOnly.Parse(msg.Text);
            }
            catch
            {
                await client.SendTextMessageAsync(chatId, "Невреный формат!");
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

            ContextRepository<Patient> db = new ContextRepository<Patient>();
            db.AddItem(patient);
            UserManager.AutorizeUser(new Models.User(chatId, patient));
            Executor.UpdateUser(chatId);

            await client.SendTextMessageAsync(chatId, "Вы успешно зарегестрированны!");
            ShowMenuBtn(chatId);
            Logger.Log($"{patient.Name} registered by phone({patient.PhoneNumber}) in chat {chatId}");

            Executor.StopListen();
        }

        private async Task GetFullName(Message msg, long chatId)
        {
            string[] input = msg.Text.Split(" ");
            if (input.Length == 3)
            {
                surname = input[0];
                name = input[1];
                lastname = input[2];
                await client.SendTextMessageAsync(chatId, $"Укажите вашу дату рождения в формате \"{DateTime.Now.ToShortDateString()}\"");
            }
            else
            {
                await client.SendTextMessageAsync(chatId, "Невреный формат!");
            }
        }

        private async Task GetPhone(Message msg, long chatId)
        {
            if (msg.Type == MessageType.Contact && msg.Contact != null)
            {
                phone = msg.Contact.PhoneNumber.Replace("+", "");
                ContextRepository<Patient> db = new ContextRepository<Patient>();
                var table = await db.GetTableAsync();
                Patient? patient = table.Find(patient => patient.PhoneNumber == phone);
                if (patient != null)
                {
                    await client.SendTextMessageAsync(chatId, "Вы уже зарегестрированы!");
                    User user = new User(chatId, patient);
                    UserManager.AutorizeUser(user);
                    Executor.UpdateUser(chatId);
                    Executor.StopListen();
                    ShowMenuBtn(chatId);
                    return;
                }
                await client.SendTextMessageAsync(chatId, "Укажите ваши ФИО в формате \"Иванов Иван Иванович\"");
            }
            else
            {
                await client.SendTextMessageAsync(chatId, "Отправьте контактом!");
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
    }
}
