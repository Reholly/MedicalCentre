using System;

namespace MedicalCentre.Models
{
    public class Note
    {
        public uint ID { get; }
        public string Title { get; }
        public string NoteText { get; }
        public DateTime PublicationDate { get; }
    }
}
