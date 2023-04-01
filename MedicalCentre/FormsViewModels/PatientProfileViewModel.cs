using MedicalCentre.DatabaseLayer;
using MedicalCentre.Models;
using MedicalCentre.ViewModels;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MedicalCentre.Forms.ViewModels
{
    internal class PatientProfileViewModel
    {
        public ICommand? CloseCommand { get; set; }
        public ICommand? SaveCommand { get; set; }
        public ICommand? DeleteCommand { get; set; }

        private readonly PatientProfile profile;
        private readonly Patient currentPatient;
        private readonly ContextRepository<Patient> _repositoryPatients;

        public PatientProfileViewModel(PatientProfile profile, Patient patient)
        {
            this.profile = profile;
            this.currentPatient = patient;

            var accDb = new ContextRepository<Account>();
            _repositoryPatients = new ContextRepository<Patient>();

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
            Patient patient = await _repositoryPatients.GetItemByIdAsync(currentPatient.Id);

            _repositoryPatients.DeleteItemAsync(patient);

            Close();
        }

        private async Task Save()
        {
            Patient patient = await _repositoryPatients.GetItemByIdAsync(currentPatient.Id);

            currentPatient.Name = profile.Name.Text;
            currentPatient.Surname = profile.Surname.Text;
            currentPatient.Patronymic = profile.Patronymic.Text;
            currentPatient.PhoneNumber = profile.PhoneNumber.Text;
            try
            {


                currentPatient.BirthDate = DateOnly.ParseExact(profile.BirthDate.Text, "d");
            }
            catch 
            {
                MessageBox.Show("Дата в неправильном формате!");
            }

            _repositoryPatients.UpdateItemAsync(patient);

            Close();
        }

        private void Close()
        {
            profile.Close();
        }
    }
}
