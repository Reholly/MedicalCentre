namespace MedicalCentre.Models
{
    public class Image
    {
        public uint Id { get; set; }
        public byte[] ImageBytes { get; set; } = null!;
    }
}
