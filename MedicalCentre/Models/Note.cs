using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MedicalCentre.Models
{
    public class Note : INotifyPropertyChanged
    {
        public uint Id { get; set; }
        public string Title { get; set; } = null!;
        public string NoteText { get; set; } = null!;
        public Patient PatientId { get; set; } = null!;
        public DateTime PublicationDate { get; set; }

        public Note() { }

        public Note(string title, string noteText, DateTime publicationDate)
        {
            Title = title;
            NoteText = noteText;
            PublicationDate = publicationDate;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
