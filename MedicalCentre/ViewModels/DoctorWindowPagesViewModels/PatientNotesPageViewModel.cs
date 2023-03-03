using MedicalCentre.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MedicalCentre.ViewModels.DoctorWindowPagesViewModels
{
    public class PatientNotesPageViewModel
    {
        public ObservableCollection<Note> Notes { get; set; }
        public PatientNotesPageViewModel(List<Note> notes)
        {
            Notes = new ObservableCollection<Note>(notes);
        }
    }
}