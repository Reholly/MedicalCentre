using System;

namespace MedicalCentre.Models
{
    public class Log
    {
        public uint Id { get; set; }
        public string LogText { get; set; } = null!;
        public bool IsSuccess { get; }
    }
}
