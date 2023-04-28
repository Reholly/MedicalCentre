using MedicalCentre.DatabaseLayer;
using MedicalCentre.Forms;
using MedicalCentre.Models;
using MedicalCentre.ViewModels;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using MedicalCentre.ViewModels.Commands;

namespace MedicalCentre.FormsViewModels;

public class CreateExaminationFormViewModel
{
    private readonly CreateExaminationForm form;
    public ICommand ChangesSavingCommand { get; set; }
    public ICommand ClosingCommand { get; set; }
    public CreateExaminationFormViewModel(CreateExaminationForm form)
    {
        this.form = form;
        ChangesSavingCommand = new RelayCommandAsync(SaveChanges);
        ClosingCommand = new RelayCommand(Close);
    }

    private async Task SaveChanges()
    {
        ContextRepository<MedicalExamination> repository = new();
        MedicalExamination examination = new MedicalExamination(
            uint.Parse(form.PatientsId.Text),
            form.Title.Text,
            form.Conclusion.Text,
            DateTime.Now);
        await repository.AddItemAsync(examination);
        form.Close();
    }

    private void Close() => form.Close();
}
