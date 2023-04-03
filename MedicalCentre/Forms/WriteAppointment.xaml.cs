using MedicalCentre.FormsViewModels;
using System.Windows;

namespace MedicalCentre.Forms
{
    public partial class WriteAppointment : Window
    {
        public WriteAppointment()
        {
            InitializeComponent();
            DataContext = new WriteAppointmentViewModel(this);
        }
    }
}
