using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MedicalCentre.Models
{
    public class Transaction : INotifyPropertyChanged
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

        public Transaction(uint id, double price, DateTime date, TransactionType type)
        {
            Id = id;
            Price = price;
            TransactionDate = date;
            Type = type;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
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
}