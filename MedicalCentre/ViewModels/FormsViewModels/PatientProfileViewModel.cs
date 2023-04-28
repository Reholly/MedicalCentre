using MedicalCentre.DatabaseLayer;
using MedicalCentre.Forms;
using MedicalCentre.Models;
using MedicalCentre.ViewModels;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using MedicalCentre.ViewModels.Commands;

namespace MedicalCentre.FormsViewModels;

public class PatientProfileViewModel
{
    public ICommand? CloseCommand { get; set; }
    public ICommand? SaveCommand { get; set; }
    public ICommand? DeleteCommand { get; set; }

    private PatientProfile profile;
    private Patient currentPatient;

    public PatientProfileViewModel(PatientProfile profile, Patient patient)
    {
        this.profile = profile;
        this.currentPatient = patient;

        var accDb = new ContextRepository<Account>();

        CloseCommand = new RelayCommand(Close);
        DeleteCommand = new RelayCommandAsync(Delete);
        SaveCommand = new RelayCommandAsync(Save);

        this.profile.Name.Text = patient.Name;
        this.profile.Surname.Text = patient.Surname;
        this.profile.Patronymic.Text = patient.Patronymic;
        this.profile.PhoneNumber.Text = patient.PhoneNumber;
        this.profile.BirthDate.Text = patient.BirthDate.ToString();
    }

    private async Task Delete()
    {
        var patientDb = new ContextRepository<Patient>();

        Patient patient = await patientDb.GetItemByIdAsync(currentPatient.Id);

        await patientDb.DeleteItemAsync(patient);

        Close();
    }

    private async Task Save()
    {
        var accDb = new ContextRepository<Patient>();
        Patient patient = await accDb.GetItemByIdAsync(currentPatient.Id);

        currentPatient.Name = profile.Name.Text;
        currentPatient.Surname = profile.Surname.Text;
        currentPatient.Patronymic = profile.Patronymic.Text;
        currentPatient.PhoneNumber = profile.PhoneNumber.Text;
        try
        {


            currentPatient.BirthDate = DateOnly.ParseExact(profile.BirthDate.Text, "d");
        }
        catch (Exception ex)
        {
            MessageBox.Show("Дата в неправильном формате!");
        }

        await accDb.UpdateItemAsync(patient);

        Close();
    }

    private void Close()
    {
        profile.Close();
    }
}

