using MedicalCentre.Models;
using System.Collections.ObjectModel;
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
            DeleteAppointmentCommand = new RelayCommand(DeleteAppointment);
        }

        private void DeleteAppointment() => Appointments.Remove(SelectedAppointment);
    }
}