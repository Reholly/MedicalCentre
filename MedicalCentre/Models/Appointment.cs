using System;

namespace MedicalCentre.Models;

public class Appointment
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
}