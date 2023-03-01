﻿using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MedicalCentre.ViewModels
{
    public class RelayCommandAsync : ICommand
    {
        private readonly Func<Task> action;
        public RelayCommandAsync(Func<Task> action) => this.action = action;
        public bool CanExecute(object? parametr) => true;
        public event EventHandler? CanExecuteChanged;
        public void Execute(object? parametr) => action();
    }
}