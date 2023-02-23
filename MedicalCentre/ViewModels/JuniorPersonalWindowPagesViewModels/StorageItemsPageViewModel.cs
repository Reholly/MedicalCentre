using MedicalCentre.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MedicalCentre.ViewModels.JuniorPersonalWindowPagesViewModels
{
    public class StorageItemsPageViewModel
    {
        public ObservableCollection<StorageItem> Items { get; set; } 
        public StorageItem SelectedItem { get; set; }
        public ICommand AddItemCommand { get; set; }
        public ICommand RemoveItemCommand { get; set; }
        public StorageItemsPageViewModel()
        {
            AddItemCommand = new RelayCommand(AddItem);
            RemoveItemCommand = new RelayCommand(RemoveItem);
        }

        private void AddItem() => Items.Add(new StorageItem());
        private void RemoveItem() => Items.Remove(SelectedItem);
    }
}