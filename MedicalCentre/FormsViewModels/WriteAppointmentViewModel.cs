using MedicalCentre.DatabaseLayer;
using MedicalCentre.Forms;
using MedicalCentre.Models;
using MedicalCentre.Services;
using MedicalCentre.ViewModels;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MedicalCentre.FormsViewModels
{

    internal class WriteAppointmentViewModel
    {
        public ICommand WriteCommand { get; set; }
        public ICommand CloseCommand { get; set; }
        private WriteAppointment currentPage;

        public WriteAppointmentViewModel(WriteAppointment page)
        {
            currentPage = page;
            WriteCommand = new RelayCommandAsync(Write);
            CloseCommand = new RelayCommand(() => currentPage.Close());
        }
        public async Task Write()
        {
            try
            {
                ContextRepository<Appointment> appointmetnDb = new();
                ContextRepository<Patient> patientDb = new();

                Patient patient = await patientDb.GetItemByIdAsync(uint.Parse(currentPage.PatientId.Text));
                Appointment appointment = await appointmetnDb.GetItemByIdAsync(uint.Parse(currentPage.AppointmentId.Text));

                appointment.PatientId = patient.Id;
                await appointmetnDb.UpdateItemAsync(appointment);
                await LoggerService.CreateLog($"patient {patient.Id} was recorded on {appointment.Id}", true);
            }
            catch (Exception ex)
            {
                await LoggerService.CreateLog(ex.Message, false);
            }
            currentPage.Close();
        }
    }
}
