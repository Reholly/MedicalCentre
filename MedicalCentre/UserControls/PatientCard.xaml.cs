using MedicalCentre.Models;
using MedicalCentre.UserControls.ViewModels;
using System.Windows.Controls;

namespace MedicalCentre.UserControls;

public partial class PatientCard : UserControl
{
    public PatientCard(Patient patient)
    {
        InitializeComponent();
        DataContext = new PatientCardViewModel(this, patient);
    }
}
