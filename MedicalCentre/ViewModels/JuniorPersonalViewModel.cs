using MedicalCentre.Pages.JuniorPersonalWindowPages;
using MedicalCentre.ViewModels.JuniorPersonalWindowPagesViewModels;
using MedicalCentre.Windows;
using System.Windows.Input;

namespace MedicalCentre.ViewModels
{
    public class JuniorPersonalViewModel
    {
        private JuniorPersonalWindow window;
        public ICommand ShowStorageItemsCommand { get; set; }
        public JuniorPersonalViewModel(JuniorPersonalWindow window)
        {
            this.window = window;
            ShowStorageItemsCommand = new RelayCommand(ShowStorageItems);
        }

        private void ShowStorageItems() => window.frame.Content = new StorageItemsPage();
    }
}