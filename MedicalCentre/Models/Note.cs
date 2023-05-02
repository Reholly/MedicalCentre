using System;

namespace MedicalCentre.Models;

public class Note
{
    public uint Id { get; set; }
    public uint PatientId { get; set; }
    public string Title { get; set; } = null!;
    public string NoteText { get; set; } = null!;
    public DateTime PublicationDate { get; set; }

    public Note() { }

    public Note(uint patientId, string title, string noteText, DateTime publicationDate)
    {
        Title = title;
        PatientId = patientId;
        NoteText = noteText;
        PublicationDate = publicationDate;
    }

    public Note(uint id, uint patientId, string title, string noteText, DateTime publicationDate)
    {
        Id = id;
        PatientId = patientId;
        Title = title;
        NoteText = noteText;
        PublicationDate = publicationDate;
    }
}