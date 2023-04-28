using MedicalCentre.Models;
using System.Windows.Controls;
using MedicalCentre.ViewModels.UserControlsViewModels;

namespace MedicalCentre.UserControls;

public partial class PatientCard : UserControl
{
    public PatientCard(Patient patient)
    {
        InitializeComponent();
        DataContext = new PatientCardViewModel(this, patient);
    }
}
