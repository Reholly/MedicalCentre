﻿using MedicalCentre.Models;
using MedicalCentre.Pages.OperatorPages;
using MedicalCentre.Services;
using MedicalCentre.ViewModels;
using System.Threading;
using System.Windows;

namespace MedicalCentre.Windows
{
    public partial class OperatorWindow : Window
    {
        public OperatorWindow(Account account)
        {

            if (Thread.CurrentPrincipal == null || !Thread.CurrentPrincipal.IsInRole("Doctor"))
            {
                Close();
            }

            InitializeComponent();

            EmployeeNameBinderService.BindName(account, RoleName, EmployeeName);

            MainFrame.Content = new MainPage();
            DataContext = new OperatorWindowViewModel(this, account);
        }
    }
}