using MedicalCentre.DatabaseLayer;
using MedicalCentre.Models;
using MedicalCentre.Services;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для DeletePatient.xaml
    /// </summary>
    public partial class DeletePatient : Window
    {
        public DeletePatient()
        {
            InitializeComponent();
        }
        public async void Delete(object sender, RoutedEventArgs e)
        {
            Database<Patient> patientDb = new Database<Patient>();

            try
            {


                var currentPatient = await patientDb.GetItemByIdAsync(uint.Parse(PatientId.Text));
                await patientDb.DeleteItemAsync(currentPatient);
            }
            catch (Exception ex)
            {
                // MessageBox.Show("Неверный ID или что-то еще. Повторите попытку позже");
                LoggerService.CreateLog(ex.Message, false);
            }
            Close();
        }
    }
}
