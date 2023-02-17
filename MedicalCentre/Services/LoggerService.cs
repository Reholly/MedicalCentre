using MedicalCentre.DatabaseLayer;
using MedicalCentre.Models;

namespace MedicalCentre.Services
{
    public static class LoggerService
    {
        public static void CreateLog(string log, bool isSuccess)
        {
            Database<Log> db = new Database<Log>();
            db.AddItem(new Log(log, isSuccess));
        }

        public static Log GetLog(Log log)
        {
            Database<Log> db = new Database<Log>();
            return db.GetItemById(log.Id); 
        }
    }
}
