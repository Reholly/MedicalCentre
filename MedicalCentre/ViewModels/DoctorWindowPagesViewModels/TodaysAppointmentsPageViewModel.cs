using MedicalCentre.Models;
using MedicalCentre.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MedicalCentre.ViewModels.DoctorWindowPagesViewModels
{
    public class TodaysAppointmentsPageViewModel
    {
        public ObservableCollection<Appointment> Appointments { get; set; } = new();
        public Appointment SelectedAppointment { get; set; }
        public ICommand AddAppointmentCommand { get; set; }
        public TodaysAppointmentsPageViewModel()
        {
            AddAppointmentCommand = new RelayCommand(AddAppointment);
        }

        private void AddAppointment() => Appointments.Add(new Appointment());
    }
}
