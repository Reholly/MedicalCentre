using MedicalCentre.Models;
using System.Windows;

namespace MedicalCentre.Forms
{
    public partial class NoteForm : Window
    {
        public NoteForm(Note note)
        {
            InitializeComponent();
            Title.Text = note.Title;
            Text.Text = note.NoteText;

        }

        private void Close_Click(object sender, RoutedEventArgs e) => Close();
    }
}