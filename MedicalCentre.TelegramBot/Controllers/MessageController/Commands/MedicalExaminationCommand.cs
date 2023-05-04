using MedicalCentre.DatabaseLayer;
using MedicalCentre.Models;
using MedicalCentre.TelegramBot.Models;
using Microsoft.VisualBasic.ApplicationServices;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using User = MedicalCentre.TelegramBot.Models.User;

namespace MedicalCentre.TelegramBot.Controllers.MessageController.Commands
{
    internal class MedicalExaminationCommand : ICommand, IListener
    {
        public string Name => "Анализы";

        public bool NeedAutorization => true;

        public CommandExecutor Executor { get; }

        public MedicalExaminationCommand(CommandExecutor executor) 
        { 
            Executor = executor;
        }

        public TelegramBotClient client => Bot.GetTelegramBot();

        private List<MedicalExamination> medicalExaminations = new List<MedicalExamination>();

        public async Task Execute(Update update)
        {
            long chatId = update.Message.Chat.Id;
            ContextRepository<MedicalExamination> dbMedEx = new ContextRepository<MedicalExamination>();
            List<MedicalExamination> medicalExaminationsAll = dbMedEx.GetTableAsync().Result;

            User? user = UserManager.GetUserByChatId(chatId);

            Executor.StartListen(this);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Выберите интересующий анализ");
            List<KeyboardButton> buttons = new List<KeyboardButton>();
            for(int i = 0; i < medicalExaminationsAll.Count; i++) 
            {
                if (medicalExaminationsAll[i].PatientId == user.Id)
                {
                    medicalExaminations.Add(medicalExaminationsAll[i]);
                    buttons.Add(new KeyboardButton((i + 1).ToString()));
                    sb.AppendLine($"{i + 1}) {medicalExaminations[i].ExaminationDate} - {medicalExaminations[i].Title}");
                }
            }

            if(medicalExaminations.Count == 0)
            {
                await client.SendTextMessageAsync(chatId, "У вас нет результотов анализов!");
                Executor.StopListen();
                return;
            }

            var selectMarkup = new ReplyKeyboardMarkup(buttons.ToArray().AddBackButton().ToRows(3))
            {
                ResizeKeyboard = true,
                OneTimeKeyboard = true
            };
            await client.SendTextMessageAsync(chatId, sb.ToString(), replyMarkup: selectMarkup);
        }

        public async Task GetUpdate(Update update)
        {
            long chatId = update.Message.Chat.Id;
            string input = update.Message.Text;
            int select;
            if(!int.TryParse(input, out select)) 
            {
                if(input == "Назад")
                {
                    Executor.StopListen();
                    await new MenuCommand().Execute(update);
                }    
                return;
            }

            select--;

            for (int i = 0; i < medicalExaminations.Count; i++)
            {
                if(select == i)
                {
                    await client.SendTextMessageAsync(chatId, $"{medicalExaminations[i].Title} - {medicalExaminations[i].Conclusion}");
                    Executor.StopListen();
                    await new MenuCommand().Execute(update);
                }
            }

        }
    }
}
