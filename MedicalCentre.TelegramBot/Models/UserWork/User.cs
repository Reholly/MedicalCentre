using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCentre.TelegramBot.Models.UserWork
{
    internal class User
    {
        public long ChatId { get; }
        public string Phone { get; }
        public string Name { get; }

        public User(long chatId, string phone, string name)
        {
            ChatId = chatId;
            Phone = phone;
            Name = name;
        }
    }
}
