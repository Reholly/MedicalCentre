namespace MedicalCentre.Models
{
    public class Image
    {
        public uint Id { get; set; }
        public byte[] ImageBytes { get; set; } = null!;

        public Image(uint id, byte[] imageBytes)
        {
            Id = id;
            ImageBytes = imageBytes;
        }
    }
}
