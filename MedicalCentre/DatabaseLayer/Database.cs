using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalCentre.DatabaseLayer
{ 
    public class Database<T> where T : class
    {
        private ApplicationContext context = new ApplicationContext();
        public async void AddItem<T>(T newItem) where T : class 
        {
            await context.Set<T>().AddAsync(newItem);
            context.SaveChangesAsync();
        }  

        public async Task<List<T>> GetTable()
        {
            return context.Set<T>().ToList();
        }

        public async Task<T> GetItemById(uint id)
        {
            return context.Set<T>().Find(id);
        }       
    }
}