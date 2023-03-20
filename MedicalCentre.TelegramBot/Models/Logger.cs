using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCentre.TelegramBot.Models
{
    public class Logger
    {
        public static void Log(string info)
        {
            Console.WriteLine($"{DateTime.Now} | {info}");
        }
    }
}
