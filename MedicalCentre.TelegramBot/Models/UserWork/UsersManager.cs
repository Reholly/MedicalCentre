using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCentre.TelegramBot.Models.UserWork
{
    internal static class UsersManager
    {
        public static List<User> Users { get; } = new List<User>();

        public static bool TryRegisterUser(long chatId, string name, string phone)
        {
            User newUser = new User(chatId, phone, name);
            if (isRegistred(newUser))
            {
                return false;
            }

            Logger.Log($"{name} registered by phone({phone}) in chat {chatId}");
            Users.Add(newUser);
            return true;
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

        private static bool isRegistred(User addUser)
        {
            foreach (var user in Users)
            {
                if (user.Phone == addUser.Phone)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
