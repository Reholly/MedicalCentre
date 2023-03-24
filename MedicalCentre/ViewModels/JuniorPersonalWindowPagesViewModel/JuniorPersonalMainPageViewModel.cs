﻿using MedicalCentre.DatabaseLayer;
using MedicalCentre.Models;
using MedicalCentre.Pages.GeneralPages;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MedicalCentre.ViewModels.JuniorPersonalWindowPagesViewModel
{
    public class JuniorPersonalMainPageViewModel
    {
        private readonly StoragePage page;
        private bool isSaved = true;
        public ObservableCollection<StorageItem> Items { get; set; }
        public StorageItem? SelectedItem { get; set; }
        public ICommand ItemAddingCommand { get; set; }
        public ICommand SavingChangesCommand { get; set; }
        public JuniorPersonalMainPageViewModel(StoragePage page)
        {
            this.page = page;
            Items = new(new ContextRepository<StorageItem>().GetTable());
            ItemAddingCommand = new RelayCommand(AddItem);
            SavingChangesCommand = new RelayCommandAsync(SaveChanges);
        }

        private void AddItem()
        {
            ContextRepository<StorageItem> repository = new();
            if (isSaved)
            {
                isSaved = false;
                Items.Add(new StorageItem());
            }
            else
            {
                MessageBox.Show("Улюлю, сначала сохрани прошлые изменения");
            }
        }

        private async Task SaveChanges()
        {
            if (!isSaved)
            {
                StorageItem item = Items[^1];
                isSaved = true;
                await new ContextRepository<StorageItem>().AddItemAsync(item);
            }
            else
            {
                MessageBox.Show("Мужик, тебе сохранять нечего");
            }
        }
    }
}