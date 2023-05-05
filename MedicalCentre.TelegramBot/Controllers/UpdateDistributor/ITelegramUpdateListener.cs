using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace MedicalCentre.TelegramBot.Controllers.UpdateDistributor
{
    internal interface ITelegramUpdateListener
    {
        public async Task GetUpdate(Update update) { }
    }
}
