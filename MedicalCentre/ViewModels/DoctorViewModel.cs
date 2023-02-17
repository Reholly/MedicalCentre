using MedicalCentre.Models;
using MedicalCentre.Windows;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using MedicalCentre.Services;

namespace MedicalCentre.ViewModels
{
    public class DoctorViewModel
    {
        public ObservableCollection<MedicalExamination> Examinations { get; set; } = new ObservableCollection<MedicalExamination>();
        public MedicalExamination SelectedExamination { get; set; }
        public ICommand AddRowCommand { get; set; }
        public ICommand ShowInputHelpCommand { get; set; }
        public ICommand CreatePatientComand { get; set; }
        private DoctorWindow window;

        public DoctorViewModel(DoctorWindow window)
        {
            this.window = window;
            AddRowCommand = new RelayCommand(AddRow);
            ShowInputHelpCommand = new RelayCommand(ShowInputHelp);
            CreatePatientComand = new RelayCommand(CreatePatient);
        }

        private void AddRow() => Examinations.Add(new MedicalExamination(new Patient(), "Test", "", null, DateTime.Now));
        private void ShowInputHelp() => MessageBox.Show("DateTime input foramt: MM/DD/YYYY HH:MM:SS AM (or PM)");
        private void CreatePatient()
        {
            window.patients.Visibility = Visibility.Visible;
            window.addPatientButton.Visibility = Visibility.Visible;
        }
    }
}