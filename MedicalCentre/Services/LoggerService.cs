using MedicalCentre.DatabaseLayer;
using MedicalCentre.Models;
using System.Threading.Tasks;

namespace MedicalCentre.Services
{
    public static class LoggerService
    {
        public static async Task CreateLog(string log, bool isSuccess)
        {
            Database<Log> db = new Database<Log>();
            await db.AddItemAsync(new Log(log, isSuccess));
        }
    }
}
