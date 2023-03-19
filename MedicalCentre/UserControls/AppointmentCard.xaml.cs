using MedicalCentre.Models;
using MedicalCentre.Pages.DoctorWindowPages;
using MedicalCentre.UserControls.ViewModels;
using System.Windows.Controls;

namespace MedicalCentre.UserControls
{
    public partial class AppointmentCard : UserControl
    {
        public AppointmentCard(Appointment appointment, DoctorMainPage page, string patient, string doctor)
        {
            InitializeComponent();
            DataContext = new AppointmentCardViewModel(this, appointment, page, patient, doctor);
        }
    }
}