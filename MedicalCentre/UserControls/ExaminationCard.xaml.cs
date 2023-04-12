using MedicalCentre.Models;
using MedicalCentre.UserControls.ViewModels;
using System.Windows.Controls;

namespace MedicalCentre.UserControls;

public partial class ExaminationCard : UserControl
{
    public ExaminationCard(MedicalExamination examination)
    {
        InitializeComponent();
        DataContext = new ExaminationCardViewModel(this, examination);
    }
}