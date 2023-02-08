using System;

namespace MedicalCentre.Models
{
    public class Note
    {
        public uint Id { get; set; }
        public string Title { get; set; } = null!;
        public string NoteText { get; set; } = null!;
        public DateTime PublicationDate { get; set; }
    }
}
