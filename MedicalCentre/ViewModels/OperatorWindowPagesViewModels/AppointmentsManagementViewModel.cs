using MedicalCentre.DatabaseLayer;
using MedicalCentre.Forms;
using MedicalCentre.Models;
using MedicalCentre.Pages.AdminWindowPages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using MedicalCentre.Pages.OperatorPages;

namespace MedicalCentre.ViewModels.OperatorWindowPagesViewModels
{
    internal class AppointmentsManagementViewModel
    {
        public ObservableCollection<Appointment> Appointments { get; set; } = new();
        public ICommand? ShowTableCommand { get; set; }
        public ICommand? CreateCommand { get; set; }
        public ICommand? WriteCommand { get; set; }
        private AppointmentsManagement page;
        public AppointmentsManagementViewModel(AppointmentsManagement page)
        {
            this.page = page;
            ShowTableCommand = new RelayCommand(ShowTable);
            CreateCommand = new RelayCommand(CreateAppointment);
            WriteCommand = new RelayCommand(WriteAppointment);
        }

        private async void ShowTable()
        {
            Database<Appointment> appointmentDb = new Database<Appointment>();

            var appointments = await appointmentDb.GetTableAsync();
            Appointments = new ObservableCollection<Appointment>(appointments);

            page.PatientsGrid.ItemsSource = Appointments;
            page.PatientsGrid.Visibility = Visibility.Visible;
        }

        private void CreateAppointment()
        {
            CreateAppointment window = new CreateAppointment();
            window.Show();
        }
        
        private void WriteAppointment()
        {
            WriteAppointment window = new WriteAppointment();
            window.Show();
        }
    }
}
