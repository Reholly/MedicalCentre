using MedicalCentre.DatabaseLayer;
using MedicalCentre.Models;
using MedicalCentre.Windows;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MedicalCentre.ViewModels.DoctorWindowPagesViewModels
{
    public class TodaysAppointmentsPageViewModel
    {
        private readonly DoctorWindow window;
        public ObservableCollection<Appointment> Appointments { get; set; }
        public Appointment SelectedAppointment { get; set; }
        public ICommand DeleteAppointmentCommand { get; set; }
        public ICommand AppointmentStartingCommand { get; set; }
        public TodaysAppointmentsPageViewModel(DoctorWindow window)
        {
            this.window = window;
            DeleteAppointmentCommand = new RelayCommandAsync(DeleteAppointment);
            AppointmentStartingCommand = new RelayCommand(StartAppointment);
            ContextRepository<Appointment> database = new();
            Appointments = new ObservableCollection<Appointment>(database.GetTable());
        }

        private async Task DeleteAppointment() //отмена приёма (хз, надо ли)
        {
            Appointment temp = SelectedAppointment;
            ContextRepository<Appointment> database = new();
            await database.DeleteItemAsync(temp);
            Appointments.Remove(temp);
        }

        private void StartAppointment() => window.MainFrame.Content = new object();
    }
}