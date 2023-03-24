using System.Windows;
using MedicalCentre.Forms.ViewModels;

namespace MedicalCentre.Forms
{
    public partial class CreateExaminationForm : Window
    {
        public CreateExaminationForm()
        {
            InitializeComponent();
            DataContext = new CreateExaminationFormViewModel(this);
        }
    }
}