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
        private static UpdateDistributor<CommandExecutor> distributor = new(Bot.GetTelegramBot());

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Update update)
        {
            distributor.Update(update);
            return Ok();
        }

        [HttpGet]
        public string Get()
        {
            return "Telegram Bot started";
        }
    }
}
