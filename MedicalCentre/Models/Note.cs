using System;

namespace MedicalCentre.Models
{
    public class Note
    {
        public uint Id { get; set; }
        public string Title { get; set; } = null!;
        public string NoteText { get; set; } = null!;
        public DateTime PublicationDate { get; set; }

        public Note(uint id, string title, string noteText, DateTime publicationDate)
        {
            Id = id;
            Title = title;
            NoteText = noteText;
            PublicationDate = publicationDate;
        }
    }
}
