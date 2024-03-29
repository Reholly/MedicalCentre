﻿using System;
using System.Windows.Input;
using MedicalCentre.Forms;
using MedicalCentre.Models;
using MedicalCentre.UserControls;
using MedicalCentre.ViewModels.Commands;

namespace MedicalCentre.ViewModels.UserControlsViewModels
{
    internal class EmployeeCardViewModel
    {
        public ICommand ProfileCommand { get; set; }
        private readonly Employee currentEmployee;
        private readonly IServiceProvider provider;
        public EmployeeCardViewModel(EmployeeCard card, Employee employee, IServiceProvider provider)
        {
            currentEmployee = employee;
            this.provider = provider;
            ProfileCommand = new RelayCommand(OpenProfile);
            card.Card.Text = employee.ToString();
        }
        
        private void OpenProfile()
        {
            var profileForm = new EmployeeProfileForm(currentEmployee, provider);
            profileForm.Show();
        }
    }
}