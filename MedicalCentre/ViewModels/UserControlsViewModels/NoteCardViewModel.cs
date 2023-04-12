using MedicalCentre.Forms;
using MedicalCentre.Models;
using MedicalCentre.ViewModels;
using System.Windows.Input;

namespace MedicalCentre.UserControls.ViewModels
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