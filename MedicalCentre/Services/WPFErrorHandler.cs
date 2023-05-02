using MedicalCentre.DatabaseLayer;
using MedicalCentre.Models;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace MedicalCentre.Services;

public class WPFErrorHandler : IErrorHandler
{
    private readonly IRepository<Log> logRepository;
    public WPFErrorHandler(IRepository<Log> logRepository)
    {
        this.logRepository = logRepository;
    }
    public async void HandleError(Exception ex)
    {
        MessageBox.Show(ex.Message);
        await Task.Run(() => LoggerService.CreateLog(ex.Message, false, logRepository));
    }
}