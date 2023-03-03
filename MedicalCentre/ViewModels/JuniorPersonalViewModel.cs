using MedicalCentre.Pages.GeneralPages;
using MedicalCentre.Pages.JuniorPersonalWindowPages;
using MedicalCentre.Windows;
using System.Windows.Input;

namespace MedicalCentre.ViewModels
{
    public class JuniorPersonalViewModel
    {
        private JuniorPersonalWindow window;
        public ICommand ShowStorageItemsCommand { get; set; }
        public ICommand StartExaminationCommand { get; set; }
        public JuniorPersonalViewModel(JuniorPersonalWindow window)
        {
            this.window = window;
            ShowStorageItemsCommand = new RelayCommand(ShowStorageItems);
            StartExaminationCommand = new RelayCommand(StartExamination);
        }

        private void ShowStorageItems() => window.frame.Content = new StoragePage();
        private void StartExamination() => window.frame.Content = new ExaminationPage();
    }
}