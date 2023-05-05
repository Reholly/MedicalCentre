using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using MedicalCentre.DatabaseLayer;
using MedicalCentre.Forms;
using MedicalCentre.Models;
using MedicalCentre.ViewModels.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace MedicalCentre.ViewModels.FormsViewModels;

public class ExaminationCreatingFormViewModel
{
    private readonly ExaminationCreatingForm creatingForm;
    private readonly IServiceProvider provider;
    public ICommand ChangesSavingCommand { get; set; }
    public ICommand ClosingCommand { get; set; }
    public ExaminationCreatingFormViewModel(ExaminationCreatingForm creatingForm, IServiceProvider provider, List<Patient> patients)
    {
        this.creatingForm = creatingForm;
        this.provider = provider;
        this.creatingForm.PatientsBox.ItemsSource = patients;
        ChangesSavingCommand = new RelayCommandAsync(SaveChanges);
        ClosingCommand = new RelayCommand(Close);
    }

    private async Task SaveChanges()
    {
        try
        {
            var patient = creatingForm.PatientsBox.SelectedItem as Patient;
            var examination = new MedicalExamination(
                patient!.Id,
                creatingForm.Title.Text,
                creatingForm.Conclusion.Text,
                DateTime.Now);
            await Task.Run(() => provider.GetRequiredService<IRepository<MedicalExamination>>().AddItemAsync(examination));
            creatingForm.Close();
        }
        catch(Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void Close() => creatingForm.Close();
}
