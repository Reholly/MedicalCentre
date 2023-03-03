using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MedicalCentre.Models
{
    public class Role : INotifyPropertyChanged
    {
        public uint Id { get; set; }
        public string Title { get; set; } = null!;

        public Role() { }

        public Role(string title)
        {
            Title = title;
        }

        public Role(uint id, string title)
        {
            Id = id;
            Title = title;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}