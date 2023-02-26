using MedicalCentre.DatabaseLayer;
using MedicalCentre.Models;
using MedicalCentre.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MedicalCentre.Forms
{
    /// <summary>
    /// Логика взаимодействия для CreateAppointment.xaml
    /// </summary>
    public partial class CreateAppointment : Window
    {
        public CreateAppointment()
        {
            InitializeComponent();

        }
        public async void Create(object sender, RoutedEventArgs e)
        {
            try
            {
                Database<Appointment> appointmentDb = new();
                Database<Employee> doctorDb = new();


                uint id = uint.Parse(Id.Text);
                uint doctorId = uint.Parse(DoctorId.Text);
                DateTime appointmentTime = DateTime.ParseExact(AppointmentTime.Text, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);                

                Employee employee = await doctorDb.GetItemByIdAsync(doctorId);
                
               
                Appointment appointment = new Appointment(id, employee.Id, appointmentTime);

                await appointmentDb.AddItemAsync(appointment);
                await LoggerService.CreateLog($"Created appointment {appointment.Id}", true);
            }
            catch(Exception ex)
            {
                await LoggerService.CreateLog(ex.Message, false);
            }
            Close();
        }
    }
}
