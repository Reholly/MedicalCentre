﻿using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using MedicalCentre.DatabaseLayer;
using MedicalCentre.Forms;
using MedicalCentre.Models;
using MedicalCentre.ViewModels.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace MedicalCentre.ViewModels.FormsViewModels;

public class PatientProfileViewModel
{
    public ICommand CloseCommand { get; set; }
    public ICommand SaveCommand { get; set; }
    public ICommand DeleteCommand { get; set; }

    private readonly PatientProfile profile;
    private readonly Patient currentPatient;
    private readonly IServiceProvider provider;

    public PatientProfileViewModel(PatientProfile profile, Patient patient, IServiceProvider provider)
    {
        this.profile = profile;
        currentPatient = patient;
        this.provider = provider;

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
        var patientDb = provider.GetRequiredService<IRepository<Patient>>();

        var patient = await patientDb.GetItemByIdAsync(currentPatient.Id);

        await patientDb.DeleteItemAsync(patient);

        Close();
    }

    private async Task Save()
    {
        var accDb = provider.GetRequiredService<IRepository<Account>>();
        var patient = await accDb.GetItemByIdAsync(currentPatient.Id);

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

