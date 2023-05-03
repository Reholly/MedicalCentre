using System;

namespace MedicalCentre.Models;

public class MedicalExamination
{
    public uint Id { get; set; } = default!;
    public DateTime ExaminationDate { get; set; } = default!;
    public uint PatientId { get; set; }
    public string Title { get; set; } = null!;
    public string Conclusion { get; set; } = null!;

    public MedicalExamination() { }

    public MedicalExamination(uint patient, string title, string conclusion, DateTime date)
    {
        PatientId = patient;
        Title = title;
        Conclusion = conclusion;
        ExaminationDate = date;
    }

    public MedicalExamination(uint id, DateTime examinationDate, uint patient, string title, string conclusion)
    {
        Id = id;
        ExaminationDate = examinationDate;
        PatientId = patient;
        Title = title;
        Conclusion = conclusion;
    }
}