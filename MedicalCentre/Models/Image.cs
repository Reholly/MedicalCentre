using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MedicalCentre.Models
{
    public class Image : INotifyPropertyChanged
    {
        public uint Id { get; set; }
        public byte[] ImageBytes { get; set; } = null!;
        
        public Image() { }

        public Image(byte[] image)
        {
            ImageBytes = image;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
