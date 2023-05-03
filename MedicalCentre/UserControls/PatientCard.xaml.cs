using System;
using MedicalCentre.Models;
using System.Windows.Controls;
using MedicalCentre.ViewModels.UserControlsViewModels;

namespace MedicalCentre.UserControls;

public partial class PatientCard : UserControl
{
    public PatientCard(Patient patient, IServiceProvider provider)
    {
        InitializeComponent();
        DataContext = new PatientCardViewModel(this, patient, provider);
    }
}
