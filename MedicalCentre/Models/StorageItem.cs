using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MedicalCentre.Models
{
    public class StorageItem : INotifyPropertyChanged
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public uint Amount { get; set; }
        public decimal Cost { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
        public StorageItem() { }
        public StorageItem(uint id, string name, uint amount, decimal cost)
        {
            Id = id;
            Name = name;
            Amount = amount;
            Cost = cost;
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}