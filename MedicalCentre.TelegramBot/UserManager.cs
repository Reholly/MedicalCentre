using MedicalCentre.DatabaseLayer;
using MedicalCentre.Models;
using MedicalCentre.TelegramBot.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCentre.TelegramBot
{
    internal class UserManager
    {
        private static List<User> Users { get; } = new List<User>();

        public static User? GetUserByChatId(long id)
        {
            return Users.Find(x => x.ChatId == id);
        }

        public static User? GetUserByPhone(string phone)
        {
            return Users.Find(x => x.PhoneNumber == phone);
        }

        public static void AutorizeUser(User user)
        {
            Users.Add(user);
        }
    }
}
