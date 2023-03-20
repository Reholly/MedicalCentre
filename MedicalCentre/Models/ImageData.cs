using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MedicalCentre.Models
{
    public class ImageData : INotifyPropertyChanged
    {
        public uint Id { get; set; }
        public byte[] ImageBytes { get; set; }

        public ImageData() { }

        public ImageData(byte[] image)
        {
            ImageBytes = image;
        }

        public ImageData(uint id, byte[] imageBytes)
        {
            Id = id;
            ImageBytes = imageBytes;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}