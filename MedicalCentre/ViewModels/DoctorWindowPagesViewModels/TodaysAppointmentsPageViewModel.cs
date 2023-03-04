using MedicalCentre.DatabaseLayer;
using MedicalCentre.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MedicalCentre.ViewModels.DoctorWindowPagesViewModels
{
    public class TodaysAppointmentsPageViewModel
    {
        public ObservableCollection<Appointment> Appointments { get; set; }
        public Appointment SelectedAppointment { get; set; }
        public ICommand DeleteAppointmentCommand { get; set; }
        public TodaysAppointmentsPageViewModel()
        {
            DeleteAppointmentCommand = new RelayCommandAsync(DeleteAppointment);
            ContextRepository<Appointment> database = new();
            Appointments = new ObservableCollection<Appointment>(database.GetTable());
        }

        private async Task DeleteAppointment()
        {
            Appointment temp = SelectedAppointment;
            ContextRepository<Appointment> database = new();
            await database.DeleteItemAsync(temp);
            Appointments.Remove(temp);
        }
    }
}