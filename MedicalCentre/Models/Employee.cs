namespace MedicalCentre.Models;

public class Employee
{
    public uint Id { get; set; }
    public uint AccountId { get; set; }
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public string Patronymic { get; set; } = null!;
    public string Specialization { get; set; } = null!;
    public string Description { get; set; } = null!;
    public double Salary { get; set; }

    public Employee() { }

    public Employee(string name, uint accId, string surname, string patronymic, string specialization, string description, double salary)
    {
        Name = name;
        AccountId = accId;
        Surname = surname;
        Patronymic = patronymic;
        Specialization = specialization;
        Description = description;
        Salary = salary;
    }
    public Employee(uint id, string name, uint accId, string surname, string patronymic, string specialization, string description, double salary)
    {
        Id = id;
        AccountId = accId;
        Name = name;
        Surname = surname;
        Patronymic = patronymic;
        Specialization = specialization;
        Description = description;
        Salary = salary;
    }

    public override string ToString()
    {
        return $"{Name[0]}.{Patronymic[0]}. {Surname} - {Specialization}";
    }
}