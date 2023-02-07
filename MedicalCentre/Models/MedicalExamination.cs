﻿using System.Collections.Generic;
using System.Windows.Controls;

namespace MedicalCentre.Models
{
    public class MedicalExamination
    {
        public uint ID { get; }
        public string Title { get; }
        public string Conclusion { get; }
        public List<Image>? Materials { get; }
    }
}
