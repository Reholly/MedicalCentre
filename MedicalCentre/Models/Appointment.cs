using MedicalCentre.DatabaseLayer;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MedicalCentre.Models
{
    public class Appointment : INotifyPropertyChanged
    {
        public uint Id { get; set; }
        public uint? PatientId { get; set; } = null;
        public uint DoctorId { get; set; }
        public DateTime AppointmentTime { get; set; }
        public bool IsFinished { get; set; } = false;

        public Appointment() { }

        public Appointment(uint id, uint? patient, uint doctor, DateTime appointmentTime)
        {
            Id = id;
            PatientId = patient;
            DoctorId = doctor;
            AppointmentTime = appointmentTime;
        }
        
        public Appointment(uint id, uint doctor, DateTime appointmentTime)
        {
            Id = id;
            DoctorId = doctor;
            PatientId = null;
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