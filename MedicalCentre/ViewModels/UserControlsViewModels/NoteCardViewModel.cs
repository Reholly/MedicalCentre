using System.Windows.Input;
using MedicalCentre.Forms;
using MedicalCentre.Models;
using MedicalCentre.UserControls;
using MedicalCentre.ViewModels.Commands;

namespace MedicalCentre.ViewModels.UserControlsViewModels
{
    public class NoteCardViewModel
    {
        private readonly Note note;
        public ICommand NoteShowingCommand { get; set; }
        public NoteCardViewModel(Note note, NoteCard card)
        {
            this.note = note;
            card.Card.Text = note.Title;
            NoteShowingCommand = new RelayCommand(ShowNote);
        }

        private void ShowNote() => new NoteForm(note).Show();
    }
}