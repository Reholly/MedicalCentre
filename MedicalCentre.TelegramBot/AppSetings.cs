using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCentre.TelegramBot
{
    internal static class AppSetings
    {
        public static string? Token;
        public static readonly TimeSpan TimeOfNotification = TimeSpan.FromMinutes(23 * 60 + 2);
    }
}
