using MedicalCentre.Models;
using System.Windows.Controls;
using MedicalCentre.ViewModels.UserControlsViewModels;

namespace MedicalCentre.UserControls;

public partial class ExaminationCard : UserControl
{
    public ExaminationCard(MedicalExamination examination)
    {
        InitializeComponent();
        DataContext = new ExaminationCardViewModel(this, examination);
    }
}