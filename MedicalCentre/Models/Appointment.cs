using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MedicalCentre.Models
{
    public class Appointment : INotifyPropertyChanged
    {
        public uint Id { get; set; }
        public Patient Patient { get; set; } = null!;
        public Employee Doctor { get; set; } = null!;
        public DateTime AppointmentTime { get; set; }
        public bool IsFinished { get; set; } = false;
        public Appointment() { }
        public Appointment(uint id, Patient patient, Employee doctor, DateTime appointmentTime)
        {
            Id = id;
            Patient = patient;
            Doctor = doctor;
            AppointmentTime = appointmentTime;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
