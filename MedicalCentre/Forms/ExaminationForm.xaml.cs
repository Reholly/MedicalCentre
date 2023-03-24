using MedicalCentre.Models;
using System.Windows;

namespace MedicalCentre.Forms
{
    public partial class ExaminationForm : Window
    {
        public ExaminationForm(MedicalExamination examination)
        {
            InitializeComponent();
            Title.Text = examination.Title;
            Text.Text = examination.Conclusion;
        }

        private void Close_Click(object sender, RoutedEventArgs e) => Close();
    }
}