using MedicalCentre.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MedicalCentre.ViewModels.GeneralViewModels
{
    public class StoragePageViewModel
    {
        public ObservableCollection<StorageItem> Items { get; set; }
        public StorageItem SelectedItem { get; set; }
        public ICommand AddItemCommand { get; set; }
        public ICommand RemoveItemCommand { get; set; }
        public StoragePageViewModel()
        {
            AddItemCommand = new RelayCommand(AddItem);
            RemoveItemCommand = new RelayCommand(RemoveItem);
        }

        private void AddItem() => Items.Add(new StorageItem());
        private void RemoveItem() => Items.Remove(SelectedItem);
    }
}