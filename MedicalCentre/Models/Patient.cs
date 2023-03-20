using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MedicalCentre.Models
{
    public class Patient : INotifyPropertyChanged
    {
        public uint Id { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Patronymic { get; set; } = null!;
        public DateOnly BirthDate { get; set; }
        public List<MedicalExamination> Examinations { get; set; } = null!;
        public List<Note> Notes { get; set; } = null!;

        public Patient()
        {
            Examinations = new();
            Notes = new();
        }

        public Patient(string phoneNumber, string name, string surname, string patronymic, DateOnly birthDate, List<MedicalExamination> examinations, List<Note> notes)
        {
            PhoneNumber = phoneNumber;
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            BirthDate = birthDate;
            Examinations = examinations;
            Notes = notes;
        }

        public Patient(uint id, string phoneNumber, string name, string surname, string patronymic, DateOnly birthDate, List<MedicalExamination> examinations, List<Note> notes)
        {
            Id = id;
            PhoneNumber = phoneNumber;
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            BirthDate = birthDate;
            Examinations = examinations;
            Notes = notes;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public override string ToString()
        {
            return $"{Name[0]}.{Patronymic[0]}.{Surname} - {BirthDate} - {PhoneNumber}";
        }

        public string ToStringForAppointment()
        {
            return ToString().Split(" - ")[0];
        }
    }
}