using System;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using MedicalCentre.DatabaseLayer;
using MedicalCentre.Forms;
using MedicalCentre.Models;
using MedicalCentre.ViewModels.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace MedicalCentre.ViewModels.FormsViewModels;

public class PatientRegistrationFormViewModel
{
    public ICommand RegisterCommand { get; set; }
    public ICommand CloseCommand { get; set; }

    private readonly PatientRegistrationFrom profile;
    private readonly IRepository<Patient> patientsRepository;

    public PatientRegistrationFormViewModel(PatientRegistrationFrom profile, IServiceProvider serviceProvider)
    {
        this.profile = profile;
        patientsRepository = serviceProvider.GetRequiredService<IRepository<Patient>>();
        RegisterCommand = new RelayCommandAsync(Register);
        CloseCommand = new RelayCommand(Close);
    }

    private async Task Register()
    {
        try
        {
            var name = profile.Name.Text;
            var surname = profile.Surname.Text;
            var patronymic = profile.Patronymic.Text;
            var phoneNumber = profile.PhoneNumber.Text;

            var birthDate = DateOnly.ParseExact(profile.BirthDate.Text, "dd.MM.yyyy", CultureInfo.InvariantCulture) ;
   
            await Task.Run(() => patientsRepository.AddItemAsync(new Patient(phoneNumber, name, surname, patronymic, birthDate, null!, null!)));
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }         
    }

    private void Close()
    {
        profile.Close();
    }
}
