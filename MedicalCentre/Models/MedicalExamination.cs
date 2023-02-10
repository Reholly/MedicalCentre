﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MedicalCentre.Models
{
    public class MedicalExamination :INotifyPropertyChanged
    {
        public uint Id { get; set; }
        public Patient Patient { get; set; }
        public string Title { get; set; } = null!;
        public string Conclusion { get; set; } = null!;
        public Image AttachedImage { get; set; } = null!;

        public MedicalExamination() { }

        public MedicalExamination(Patient patient, string title, string conclusion, Image attachedImage)
        {
            Patient = patient;
            Title = title;
            Conclusion = conclusion;
            AttachedImage = attachedImage;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
