using System;
using System.Windows;
using MedicalCentre.ViewModels.FormsViewModels;

namespace MedicalCentre.Forms
{
    public partial class CreateExaminationForm : Window
    {
        public CreateExaminationForm(IServiceProvider provider)
        {
            InitializeComponent();
            DataContext = new ExaminationCreatingFormViewModel(this, provider);
        }
    }
}