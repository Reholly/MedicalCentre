using MedicalCentre.Models;
using MedicalCentre.TelegramBot.DataBaseLayer;
using MedicalCentre.TelegramBot.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCentre.TelegramBot
{
    internal static class UsersManager
    {
        public static List<User> Users { get; } = new List<User>();

        public static void AddUser(User user)
        {
            Users.Add(user);
        }

        public static User? GetUserByChatId(long chatId)
        {
            foreach (var user in Users)
            {
                if (user.ChatId == chatId)
                {
                    return user;
                }
            }
            return null;
        }
    }
}
