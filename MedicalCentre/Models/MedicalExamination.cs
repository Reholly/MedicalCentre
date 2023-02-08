using System.Collections.Generic;   

namespace MedicalCentre.Models
{
    public class MedicalExamination
    {
        public uint Id { get; set; }
        public string Title { get; set; } = null!;
        public string Conclusion { get; set; } = null!;
        public List<byte[]> MaterialsImages { get; set; } = null!;
    }
}
