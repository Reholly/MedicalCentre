using MedicalCentre.Forms.ViewModels;
using System.Windows;

namespace MedicalCentre.Forms
{
    public partial class CreateAppointment : Window
    {
        public CreateAppointment()
        {
            InitializeComponent();
            DataContext = new CreateAppointmentViewModel(this);
        }
    }
}