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

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
