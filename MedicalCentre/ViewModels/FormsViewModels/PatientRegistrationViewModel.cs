using MedicalCentre.DatabaseLayer;
using MedicalCentre.Forms;
using MedicalCentre.Models;
using MedicalCentre.ViewModels;
using System;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MedicalCentre.FormsViewModels;

public class PatientRegistrationViewModel
{
    public ICommand? RegisterCommand { get; set; }
    public ICommand? CloseCommand { get; set; }

    private PatientRegistration profile;

    public PatientRegistrationViewModel(PatientRegistration profile)
    {
        this.profile = profile;
        RegisterCommand = new RelayCommandAsync(Register);
        CloseCommand = new RelayCommand(Close);
    }

    public async Task Register()
    {
        string name = profile.Name.Text;
        string surname = profile.Surname.Text;
        string patronymic = profile.Patronymic.Text;
        string phoneNumber = profile.PhoneNumber.Text;

        DateOnly birthDate = DateOnly.ParseExact(profile.BirthDate.Text, "d", CultureInfo.InvariantCulture);

        var patientDb = new ContextRepository<Patient>();
        await patientDb.AddItemAsync(new Patient(phoneNumber, name, surname, patronymic, birthDate, null, null));
    }

    public void Close()
    {
        profile.Close();
    }
}
