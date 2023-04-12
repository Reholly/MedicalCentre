using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MedicalCentre.ViewModels;

public class RelayCommandAsync : ICommand
{
    private bool isExecuting;
    private Func<Task> asyncDelegate;
    public bool IsExecuting
    {
        get
        {
            return isExecuting;
        }
        set
        {
            isExecuting = value;
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }

    public event EventHandler? CanExecuteChanged;    

    public RelayCommandAsync(Func<Task> asyncDelegate)
    {
        this.asyncDelegate = asyncDelegate;
    }

    public bool CanExecute(object parameter)
    {
        return !IsExecuting;
    }

    public async void Execute(object parameter)
    {
        IsExecuting = true;

        await ExecuteAsync();

        IsExecuting = false;
    }

    private async Task ExecuteAsync()
    {
        await asyncDelegate();
    }
}
