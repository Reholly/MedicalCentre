using System;

namespace MedicalCentre.Models
{
    public class Log
    {
        public uint Id { get; }
        public string Name { get; }
        public Action Action { get; }
        public bool IsSuccess { get; }
    }
}
