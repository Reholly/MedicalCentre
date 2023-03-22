using MedicalCentre.DatabaseLayer;
using MedicalCentre.Models;
using System.Threading.Tasks;

namespace MedicalCentre.Services;

public static class LoggerService
{
    public static async Task CreateLog(string log, bool isSuccess)
    {
        ContextRepository<Log> db = new ContextRepository<Log>();
        await db.AddItemAsync(new Log(log, isSuccess));
    }
}
