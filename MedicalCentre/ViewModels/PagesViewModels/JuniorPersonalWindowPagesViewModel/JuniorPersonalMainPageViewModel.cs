using MedicalCentre.DatabaseLayer;
using MedicalCentre.Forms;
using MedicalCentre.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MedicalCentre.ViewModels.JuniorPersonalWindowPagesViewModel;

public class JuniorPersonalMainPageViewModel
{
    public ObservableCollection<StorageItem> Items { get; set; }
    public StorageItem? SelectedItem { get; set; }
    public ICommand ItemAddingCommand { get; set; }
    public ICommand SavingChangesCommand { get; set; }
    public ICommand ExaminationStartingCommand { get; set; }

    private bool isSaved = true;
    private IServiceCollection services;
    private IRepository<StorageItem> storageRepository;
    public JuniorPersonalMainPageViewModel(IServiceCollection services)
    {
        this.services = services;

        storageRepository = services.BuildServiceProvider().GetRequiredService<IRepository<StorageItem>>();
        Items = new(storageRepository.GetTable());
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
            MessageBox.Show("Улюлю, сначала сохрани прошлые изменения");
        }
    }

    private async Task SaveChanges()
    {
        if (!isSaved)
        {
            StorageItem item = Items[^1];
            isSaved = true;
            await Task.Run(() => storageRepository.AddItemAsync(item));
        }
        else
        {
            MessageBox.Show("Мужик, тебе сохранять нечего");
        }
    }

    private void StartExamination() => new CreateExaminationForm().Show();
}