using System;
using System.Windows.Input;

namespace MedicalCentre.ViewModels
{
    public class RelayCommand : ICommand
    {
        private readonly Action action;
        public RelayCommand(Action action) => this.action = action;
        public bool CanExecute(object parametr) => true;
#pragma warning disable CS0067
        public event EventHandler CanExecuteChanged;
#pragma warning restore CS0067
        public void Execute(object parametr) => action();
    }
}