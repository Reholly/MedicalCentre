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
        public TransactionType Type { get; set; }

        public Transaction() { }

        public Transaction(double price, DateTime transactionDate)
        {
            Price = price;
            TransactionDate = transactionDate;
        }

        public Transaction(uint id, double price, DateTime transactionDate)
        {
            Id = id;
            Price = price;
            TransactionDate = transactionDate;
        }

        public Transaction(uint id, double price, DateTime Date, TransactionType type)
        {
            Id = id;
            Price = price;
            TransactionDate = Date;
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
        Purchase,
        Sale
    }
}
