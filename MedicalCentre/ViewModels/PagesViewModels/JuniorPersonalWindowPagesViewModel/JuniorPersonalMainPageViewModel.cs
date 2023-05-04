using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using MedicalCentre.DatabaseLayer;
using MedicalCentre.Forms;
using MedicalCentre.Models;
using MedicalCentre.Pages.JuniorPersonalWindowPages;
using MedicalCentre.ViewModels.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace MedicalCentre.ViewModels.PagesViewModels.JuniorPersonalWindowPagesViewModel;

public class JuniorPersonalMainPageViewModel
{
    private ObservableCollection<StorageItem> Items { get; set; }
    public StorageItem? SelectedItem { get; set; }
    public ICommand ItemAddingCommand { get; set; }
    public ICommand SavingChangesCommand { get; set; }
    public ICommand ExaminationStartingCommand { get; set; }

    private bool isSaved = true;
    private readonly IRepository<StorageItem> storageRepository;
    private readonly IServiceProvider provider;
    public JuniorPersonalMainPageViewModel(IServiceProvider serviceProvider, StoragePage page)
    {
        provider = serviceProvider;
        storageRepository = serviceProvider.GetRequiredService<IRepository<StorageItem>>();
        Items = new ObservableCollection<StorageItem>(storageRepository.GetTable());
        page.Items.ItemsSource = Items;
        ItemAddingCommand = new RelayCommand(AddItem);
        SavingChangesCommand = new RelayCommandAsync(SaveChanges);
        ExaminationStartingCommand = new RelayCommand(StartExamination);
    }

    private void AddItem()
    {
        if (isSaved)
        {
            isSaved = false;
            Items.Add(new StorageItem());
        }
        else
        {
            MessageBox.Show("Сначала нужно сохранить прошлые изменения");
        }
    }

    private async Task SaveChanges()
    {
        try
        {
            if (!isSaved)
            {
                var item = Items[^1];
                isSaved = true;
                await Task.Run(() => storageRepository.AddItemAsync(item));
            }
            else
            {
                MessageBox.Show("Вам нечего сохранять");
            }
        }
        catch(Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
    }

    private void StartExamination() => new CreateExaminationForm(provider).Show();
}