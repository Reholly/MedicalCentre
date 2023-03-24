using MedicalCentre.Forms.ViewModels;
using System.Windows;

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