using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MedicalCentre.Models
{
    public class MedicalExamination : INotifyPropertyChanged
    {
        public uint Id { get; set; } = default!;
        public DateTime ExaminationDate { get; set; } = default!;
        public Patient Patient { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Conclusion { get; set; } = null!;
        public Image AttachedImage { get; set; } = null!;

        public MedicalExamination() { }

        public MedicalExamination(Patient patient, string title, string conclusion, Image attachedImage, DateTime date)
        {
            Patient = patient;
            Title = title;
            Conclusion = conclusion;
            AttachedImage = attachedImage;
            ExaminationDate = date;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
