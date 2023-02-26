using MedicalCentre.DatabaseLayer;
using MedicalCentre.Models;
using MedicalCentre.Services;
using System;
using System.Windows;

namespace MedicalCentre.Forms
{
    public partial class WriteAppointment : Window
    {
        public WriteAppointment()
        {
            InitializeComponent();
        }
        public async void Write(object sender, RoutedEventArgs e)
        {
            try
            {
                Database<Appointment> appointmetnDb = new();
                Database<Patient> patientDb = new();

                Patient patient = await patientDb.GetItemByIdAsync(uint.Parse(PatientId.Text));
                Appointment appointment = await appointmetnDb.GetItemByIdAsync(uint.Parse(AppointmentId.Text));

                appointment.PatientId = patient.Id;
                appointmetnDb.UpdateItemAsync(appointment);
                LoggerService.CreateLog($"patient {patient.Id} was recorded on {appointment.Id}", true);
            }
            catch(Exception ex)
            {
                LoggerService.CreateLog(ex.Message, false);
            }
            Close();
        }
    }
}
