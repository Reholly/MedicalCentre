﻿using MedicalCentre.DatabaseLayer;
using MedicalCentre.Models;
using MedicalCentre.ViewModels;
using System;
using System.Windows.Input;

namespace MedicalCentre.Forms.ViewModels
{
    public class CreateExaminationFormViewModel
    {
        private readonly CreateExaminationForm form;
        public ICommand ChangesSavingCommand { get; set; }
        public ICommand ClosingCommand { get; set; }
        public CreateExaminationFormViewModel(CreateExaminationForm form)
        {
            this.form = form;
            ChangesSavingCommand = new RelayCommand(SaveChanges);
            ClosingCommand = new RelayCommand(Close);
        }

        private void SaveChanges()
        {
            ContextRepository<MedicalExamination> repository = new();
            MedicalExamination examination = new MedicalExamination(
                uint.Parse(form.PatientsId.Text),
                form.Title.Text,
                form.Conclusion.Text,
                DateTime.Now);
            repository.AddItem(examination);
            form.Close();
        }

        private void Close() => form.Close();
    }
}