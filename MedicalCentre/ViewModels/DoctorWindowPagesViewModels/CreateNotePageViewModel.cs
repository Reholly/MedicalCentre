using MedicalCentre.Models;
using MedicalCentre.Pages.DoctorWindowPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MedicalCentre.ViewModels.DoctorWindowPagesViewModels
{
    public class CreateNotePageViewModel
    {
        private readonly CreateNotePage page;
        public ICommand SaveNoteCommand { get; set; }
        public CreateNotePageViewModel(CreateNotePage page)
        {
            this.page = page;
            SaveNoteCommand = new RelayCommand(SaveNote);
        }

        private void SaveNote()
        {
            page.CreatedNote = new Note(page.NoteTitleBox.Text, page.NoteTextBox.Text, DateTime.Now);
            page.IsCreated = true;
        }
    }
}
