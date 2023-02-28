using MedicalCentre.Models;
using MedicalCentre.Pages.GeneralPages;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MedicalCentre.Services;
using MedicalCentre.DatabaseLayer;
using Microsoft.EntityFrameworkCore.Storage;

namespace MedicalCentre.ViewModels.GeneralViewModels
{
    public class StoragePageViewModel
    {
        private StoragePage page;
        public ObservableCollection<StorageItem> Items { get; set; }
        public StorageItem SelectedItem { get; set; }
        public ICommand AddItemCommand { get; set; }
        public ICommand RemoveItemCommand { get; set; }
        public StoragePageViewModel(StoragePage page)
        {
            this.page = page;
            AddItemCommand = new RelayCommand(AddItem);
            RemoveItemCommand = new RelayCommand(RemoveItem);
        }

        private async void AddItem()
        {
            StorageItem storageItem = new();
            Items.Add(storageItem);
            LoggerService.CreateLog("Storage item added", true);
            Database<StorageItem> database= new Database<StorageItem>();
            await database.AddItemAsync(storageItem);
        }
        private void RemoveItem() 
        {
            Items.Remove(SelectedItem);
            LoggerService.CreateLog("Storage item deleted", true);
        }
    }
}