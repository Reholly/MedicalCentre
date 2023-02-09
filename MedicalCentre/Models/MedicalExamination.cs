namespace MedicalCentre.Models
{
    public class MedicalExamination
    {
        public uint Id { get; set; }
        public uint PatientId { get; set; }
        public string Title { get; set; } = null!;
        public string Conclusion { get; set; } = null!;
        public Image AttachedImage { get; set; } = null!;
    }
}
