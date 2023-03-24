﻿using MedicalCentre.DatabaseLayer;
using MedicalCentre.Forms;
using MedicalCentre.Models;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace MedicalCentre.ViewModels.JuniorPersonalWindowPagesViewModel
{
    public class JuniorPersonalMainPageViewModel
    {
        private bool isSaved = true;
        public ObservableCollection<StorageItem> Items { get; set; }
        public StorageItem? SelectedItem { get; set; }
        public ICommand ItemAddingCommand { get; set; }
        public ICommand SavingChangesCommand { get; set; }
        public ICommand ExaminationStartingCommand { get; set; }
        public JuniorPersonalMainPageViewModel()
        {
            Items = new(new ContextRepository<StorageItem>().GetTable());
            ItemAddingCommand = new RelayCommand(AddItem);
            SavingChangesCommand = new RelayCommand(SaveChanges);
            ExaminationStartingCommand = new RelayCommand(StartExamination);
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

        private void SaveChanges()
        {
            if (!isSaved)
            {
                StorageItem item = Items[^1];
                isSaved = true;
                new ContextRepository<StorageItem>().AddItem(item);
            }
            else
            {
                MessageBox.Show("Мужик, тебе сохранять нечего");
            }
        }

        private void StartExamination() => new CreateExaminationForm().Show();
    }
}