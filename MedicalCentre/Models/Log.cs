using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MedicalCentre.Models
{
    public class Log : INotifyPropertyChanged
    {
        public uint Id { get; set; }
        public string LogText { get; set; } = null!;
        public bool IsSuccess { get; set; }

        public Log() { }

        public Log(string logText, bool isSuccess)
        {
            LogText = logText;
            IsSuccess = isSuccess;
        }

        public Log(uint id, string logText, bool isSuccess)        {
            Id = id;
            LogText = logText;
            IsSuccess = isSuccess;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
