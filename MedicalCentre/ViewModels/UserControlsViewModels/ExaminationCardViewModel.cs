using System.Windows.Input;
using MedicalCentre.Forms;
using MedicalCentre.Models;
using MedicalCentre.UserControls;
using MedicalCentre.ViewModels.Commands;

namespace MedicalCentre.ViewModels.UserControlsViewModels
{
    public class ExaminationCardViewModel
    {
        private readonly MedicalExamination examination;
        public ICommand ExaminationShowingCommand { get; set; }

        public ExaminationCardViewModel(ExaminationCard card, MedicalExamination examination)
        {
            this.examination = examination;
            card.Card.Text = examination.Title;
            ExaminationShowingCommand = new RelayCommand(ShowExamination);
        }

        private void ShowExamination() => new ExaminationForm(examination).Show();
    }
}