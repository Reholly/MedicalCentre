using MedicalCentre.Models;
using MedicalCentre.ViewModels.DoctorWindowPagesViewModels;
using System.Windows.Controls;

namespace MedicalCentre.Pages.DoctorWindowPages
{
    public partial class CreateNotePage : Page
    {
        public Note CreatedNote { get; set; }
        public bool IsCreated { get; set; } = false;
        public CreateNotePage()
        {
            InitializeComponent();
            DataContext = new CreateNotePageViewModel(this);
        }
    }
}