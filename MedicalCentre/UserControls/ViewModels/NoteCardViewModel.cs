using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MedicalCentre.Forms;
using MedicalCentre.Models;
using MedicalCentre.ViewModels;

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