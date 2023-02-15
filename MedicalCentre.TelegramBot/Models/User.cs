using MedicalCentre.Models;
using MedicalCentre.TelegramBot.MessageController;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCentre.TelegramBot.Models
{
    internal class User
    {
        private Patient patient { get; set; }

        public long ChatId { get; }

        public uint Id => patient.Id;
        public string PhoneNumber => patient.PhoneNumber;
        public string Name => patient.Name;
        public string Surname => patient.Surname;
        public string Patronymic => patient.Patronymic;
        public DateOnly BirthDate => patient.BirthDate;
        public List<MedicalExamination> Examinations => patient.Examinations;
        public List<Note> Notes => patient.Notes;

        public User(long chatId, Patient patient)
        {
            ChatId = chatId;
            this.patient = patient;
        }

        public Patient GetAsPatient()
        {
            return patient;
        }
    }
}
