using System;
using System.Collections.Generic;

namespace MedicalCentre.Models
{
    public class Log
    {
        public uint ID { get; }
        public string Name { get; }
        public Action Action { get; }
        public bool IsSuccess { get; }
    }
}
