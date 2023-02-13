using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MedicalCentre.Models
{
    public class MedicalExamination : INotifyPropertyChanged
    {
        public uint Id { get; set; } = default!;
        public DateTime ExaminationDate { get; set; } = default!;
        public Patient Patient { get; set; }
        public string Title { get; set; } = null!;
        public string Conclusion { get; set; } = null!;
        public ImageData AttachedImage { get; set; } = null!;

        public MedicalExamination() { }

        public MedicalExamination(Patient patient, string title, string conclusion, ImageData attachedImage, DateTime date)
        {
            Patient = patient;
            Title = title;
            Conclusion = conclusion;
            AttachedImage = attachedImage;
            ExaminationDate = date;
        }
        public MedicalExamination(uint id, DateTime examinationDate, Patient patient, string title, string conclusion, ImageData attachedImage)
        {
            Id = id;
            ExaminationDate = examinationDate;
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
