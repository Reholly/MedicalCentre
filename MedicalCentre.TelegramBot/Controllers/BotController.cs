using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;
using Telegram.Bot;
using MedicalCentre.TelegramBot.Controllers.MessageController;
using MedicalCentre.TelegramBot.Controllers.UpdateDistributor;
using MedicalCentre.TelegramBot.Models;

namespace MedicalCentre.TelegramBot.Controllers
{
    [ApiController]
    [Route("api/bot")]
    public class BotController : ControllerBase
    {
        private static UpdateDistributor<CommandExecutor> distributor = new();

        [HttpPost]
        public async Task Post([FromBody] Update update)
        {
            await distributor.Update(update);
        }

        [HttpGet]
        public string Get()
        {
            return "Telegram bot was started";
        }
    }
}
