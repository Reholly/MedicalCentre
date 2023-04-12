using System;
using System.Threading.Tasks;
using System.Windows;

namespace MedicalCentre.Services;

public class WPFErrorHandler : IErrorHandler
{
    public async void HandleError(Exception ex)
    {
        MessageBox.Show(ex.Message);
        await Task.Run(() => LoggerService.CreateLog(ex.Message, false));
    }
}