using System;

namespace MedicalCentre.Models;

public class Transaction 
{
    public uint Id { get; set; }
    public double Price { get; set; }
    public DateTime TransactionDate { get; set; }
    public string Title { get; set; }
    public TransactionType Type { get; set; }

    public Transaction() { }

    public Transaction(double price, DateTime transactionDate, string title, TransactionType type)
    {
        Price = price;
        TransactionDate = transactionDate;
        Title = title;
        Type = type;
    }

    public Transaction(uint id, double price, DateTime transactionDate, string title, TransactionType type)
    {
        Id = id;
        Price = price;
        TransactionDate = transactionDate;
        Title = title;
        Type = type;
    }

    public Transaction(uint id, double price, DateTime Date, TransactionType type)
    {
        Id = id;
        Price = price;
        TransactionDate = Date;
        Type = type;
    }
}

public enum TransactionType
{
    AppointmentTransaction,
    ExaminationTransaction,
    SalaryTransaction,
    ItemAddTransaction,
    ItemRemoveTransaction
}