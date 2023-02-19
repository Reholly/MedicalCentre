using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MedicalCentre.Models;

namespace MedicalCentre.ViewModels.DoctorWindowPagesViewModels
{
    public class PatientNotesPageViewModel
    {
        public ObservableCollection<Note> Notes { get; set; }
        public PatientNotesPageViewModel(IEnumerable<Note> notes)
        {
            Notes = (ObservableCollection<Note>)notes;
        }
    }
}
