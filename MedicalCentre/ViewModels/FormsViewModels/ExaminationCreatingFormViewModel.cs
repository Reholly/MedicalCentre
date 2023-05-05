using System;
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
    private readonly CreateExaminationForm form;
    private readonly IServiceProvider provider;
    public ICommand ChangesSavingCommand { get; set; }
    public ICommand ClosingCommand { get; set; }
    public ExaminationCreatingFormViewModel(CreateExaminationForm form, IServiceProvider provider)
    {
        this.form = form;
        this.provider = provider;
        ChangesSavingCommand = new RelayCommandAsync(SaveChanges);
        ClosingCommand = new RelayCommand(Close);
    }

    private async Task SaveChanges()
    {
        try
        {
            var examination = new MedicalExamination(
                uint.Parse(form.PatientsId.Text),
                form.Title.Text,
                form.Conclusion.Text,
                DateTime.Now);
            await Task.Run(() => provider.GetRequiredService<IRepository<MedicalExamination>>().AddItemAsync(examination));
            form.Close();
        }
        catch(Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void Close() => form.Close();
}
