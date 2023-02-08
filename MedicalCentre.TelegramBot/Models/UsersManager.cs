using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCentre.TelegramBot.Models
{
    internal static class UsersManager
    {
        private static List<User> users = new List<User>();

        public static bool TryRegisterUser(long chatId, string name, string phone)
        {
            User newUser = new User(chatId, phone, name);
            if (isRegistred(newUser))
            {               
                return false;
            }

            Logger.Log($"{name} registered by phone({phone}) in chat {chatId}");
            users.Add(newUser);
            return true;
        }

        public static User GetUserByChatId(long chatId)
        {
            foreach (var user in users)
            {
                if (user.ChatId == chatId)
                {
                    return user;
                }
            }

            throw new ArgumentException("Несуществующий пользователь!");
        }

        private static bool isRegistred(User addUser)
        {
            foreach (var user in users)
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
