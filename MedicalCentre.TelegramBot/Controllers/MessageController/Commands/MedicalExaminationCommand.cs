using MedicalCentre.DatabaseLayer;
using MedicalCentre.Models;
using MedicalCentre.TelegramBot.DataBaseLayer;
using MedicalCentre.TelegramBot.Models;
using Microsoft.VisualBasic.ApplicationServices;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using User = MedicalCentre.TelegramBot.Models.User;

namespace MedicalCentre.TelegramBot.Controllers.MessageController.Commands
{
    internal class MedicalExaminationCommand : Command, IListener
    {
        public override string Name => "Анализы";

        public CommandExecutor Executor { get; }

        public MedicalExaminationCommand(CommandExecutor executor) 
        { 
            Executor = executor;
        }

        protected override TelegramBotClient client => Bot.GetTelegramBot();

        private List<MedicalExamination> medicalExaminations = new List<MedicalExamination>();

        public override void Execute(Update update)
        {
            long chatId = update.Message.Chat.Id;
            Database<MedicalExamination> dbMedEx = new Database<MedicalExamination>();
            List<MedicalExamination> medicalExaminationsAll = dbMedEx.GetTable();

            User? user = DatabaseTelegram.Users.Find(x => x.ChatId == chatId);
            if (user == null)
            {
                KeyboardButton regsterBtn = new KeyboardButton("Регистрация");
                var regsterMarkup = new ReplyKeyboardMarkup(regsterBtn)
                {
                    ResizeKeyboard = true,
                    OneTimeKeyboard = true
                };
                client.SendTextMessageAsync(update.Message.Chat.Id, "Для начала работы зарегестрируйтесь или авторизуйтесь!", replyMarkup: regsterMarkup);
                return;
            }

            Executor.StartListen(this);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Выберите интересующий анализ");
            List<KeyboardButton> buttons = new List<KeyboardButton>();
            for(int i = 0; i < medicalExaminationsAll.Count; i++) 
            {
                if (medicalExaminationsAll[i].Patient.Id == user.Id)
                {
                    medicalExaminations.Add(medicalExaminationsAll[i]);
                    buttons.Add(new KeyboardButton(i.ToString()));
                    sb.AppendLine($"{i}) {medicalExaminations[i].ExaminationDate} - {medicalExaminations[i].Title}");
                }
            }

            if(medicalExaminations.Count == 0)
            {
                client.SendTextMessageAsync(chatId, "У вас нет результотов анализов!");
                Executor.StopListen();
                return;
            }

            var selectMarkup = new ReplyKeyboardMarkup(buttons)
            {
                ResizeKeyboard = true,
                OneTimeKeyboard = true
            };

            client.SendTextMessageAsync(chatId, sb.ToString(), replyMarkup: selectMarkup);
        }

        public void GetUpdate(Update update)
        {
            long chatId = update.Message.Chat.Id;
            string input = update.Message.Text;
            int select;
            if(!int.TryParse(input, out select)) 
            {
                if(input == "Назад")
                {
                    Executor.StopListen();
                }    
                return;
            }

            for (int i = 0; i < medicalExaminations.Count; i++)
            {
                if(select == i)
                {
                    client.SendTextMessageAsync(chatId, $"{medicalExaminations[i].Title} - {medicalExaminations[i].Conclusion}");
                    var photo = new InputMedia(new MemoryStream(medicalExaminations[i].AttachedImage.ImageBytes), "photo.jpg");
                    client.SendPhotoAsync(chatId, photo);

                    KeyboardButton backBtn = new KeyboardButton("Назад");
                    var backMarkup = new ReplyKeyboardMarkup(backBtn)
                    {
                        ResizeKeyboard = true,
                        OneTimeKeyboard = true
                    };
                    client.SendTextMessageAsync(chatId, "Чтобы выйти напишите Назад", replyMarkup: backMarkup);
                }
            }
        }
    }
}
