using System;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Input;
using MedicalCentre.DatabaseLayer;
using MedicalCentre.Forms;
using MedicalCentre.Models;
using MedicalCentre.ViewModels.Commands;

namespace MedicalCentre.ViewModels.FormsViewModels;

public class PatientRegistrationFormViewModel
{
    public ICommand RegisterCommand { get; set; }
    public ICommand CloseCommand { get; set; }

    private readonly PatientRegistrationFrom profile;

    public PatientRegistrationFormViewModel(PatientRegistrationFrom profile)
    {
        this.profile = profile;
        RegisterCommand = new RelayCommandAsync(Register);
        CloseCommand = new RelayCommand(Close);
    }

    private async Task Register()
    {
        var name = profile.Name.Text;
        var surname = profile.Surname.Text;
        var patronymic = profile.Patronymic.Text;
        var phoneNumber = profile.PhoneNumber.Text;

        var birthDate = DateOnly.ParseExact(profile.BirthDate.Text, "d", CultureInfo.InvariantCulture);

        var patientDb = new ContextRepository<Patient>();
        await Task.Run(() => patientDb.AddItemAsync(new Patient(phoneNumber, name, surname, patronymic, birthDate, null!, null!)));
    }

    private void Close()
    {
        profile.Close();
    }
}
