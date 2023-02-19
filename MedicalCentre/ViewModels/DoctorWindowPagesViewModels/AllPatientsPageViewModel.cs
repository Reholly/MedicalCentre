using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MedicalCentre.Models;
using MedicalCentre.Services;

namespace MedicalCentre.ViewModels.DoctorWindowPagesViewModels
{
    public class AllPatientsPageViewModel
    {
        public ObservableCollection<Patient> Patients { get; set; } = new();
        public Patient SelectedPatient { get; set; }
        public ICommand AddPatientCommand { get; set; }
        public AllPatientsPageViewModel()
        {
            AddPatientCommand = new RelayCommand(AddPatient);
        }

        private void AddPatient() => Patients.Add(new Patient());
    }
}
