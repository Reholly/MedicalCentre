using MedicalCentre.Models;
using MedicalCentre.ViewModels.DoctorWindowPagesViewModels;
using System.Collections.Generic;
using System.Windows.Controls;

namespace MedicalCentre.Pages.DoctorWindowPages
{
    public partial class PatientsNotesPage : Page
    {
        public PatientsNotesPage(List<Note>notes)
        {
            InitializeComponent();
            DataContext = new PatientNotesPageViewModel(notes);
        }
    }
}