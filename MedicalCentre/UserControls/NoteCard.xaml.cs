using MedicalCentre.Models;
using MedicalCentre.UserControls.ViewModels;
using System.Windows.Controls;

namespace MedicalCentre.UserControls
{
    public partial class NoteCard : UserControl
    {
        public NoteCard(Note note)
        {
            InitializeComponent();
            DataContext = new NoteCardViewModel(note, this);
        }
    }
}