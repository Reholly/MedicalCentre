using MedicalCentre.Models;
using System.Windows.Controls;
using MedicalCentre.ViewModels.UserControlsViewModels;

namespace MedicalCentre.UserControls;

public partial class NoteCard : UserControl
{
    public NoteCard(Note note)
    {
        InitializeComponent();
        DataContext = new NoteCardViewModel(note, this);
    }
}