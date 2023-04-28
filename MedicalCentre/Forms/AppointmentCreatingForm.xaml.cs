using System.Windows;
using MedicalCentre.ViewModels.FormsViewModels;

namespace MedicalCentre.Forms;

public partial class AppointmentCreatingForm : Window
{
    public AppointmentCreatingForm()
    {
        InitializeComponent();
        DataContext = new AppointmentCreatingFormViewModel(this);
    }
}
