using MedicalCentre.DatabaseLayer;
using MedicalCentre.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MedicalCentre.ViewModels.DoctorWindowPagesViewModels
{
    public class TodaysAppointmentsPageViewModel
    {
        public ObservableCollection<Appointment> Appointments { get; set; } = new();
        public Appointment SelectedAppointment { get; set; }
        public ICommand DeleteAppointmentCommand { get; set; }
        public TodaysAppointmentsPageViewModel()
        {
            DeleteAppointmentCommand = new RelayCommandAsync(DeleteAppointment);
        }

        private async Task DeleteAppointment()
        {
            Appointment temp = SelectedAppointment;
            Database<Appointment> database = new();
            await database.DeleteItemAsync(temp);
            Appointments.Remove(temp);
        }
    }
}