using System;
using System.Collections.Generic;
using System.Windows;

namespace MedicalCentre.Models;

public class Patient 
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

    public override string ToString()
    {
        try
        {
            string result = $"{Name[0]}.{Patronymic[0]}.{Surname} - {BirthDate} - {PhoneNumber}";
            return result;
        }
        catch (Exception)
        {
            return "";
        }
    }

    public string ToStringForAppointment()
    {
        return ToString().Split(" - ")[0];
    }
}