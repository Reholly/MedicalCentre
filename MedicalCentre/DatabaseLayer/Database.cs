using System.Collections.Generic;
using System.Linq;

namespace MedicalCentre.DatabaseLayer
{ 
    public class Database<T> where T : class
    {
        private ApplicationContext context = new ApplicationContext();
        public async void AddItem<T>(T newItem) where T : class
        {
            await context.Set<T>().AddAsync(newItem);
            await context.SaveChangesAsync();
        }  

        public List<T> GetTable()
        {
            return context.Set<T>().ToList();
        }

        public T GetItem(T item)
        {
            return context.Set<T>().Find(item);
        }       
    }
}
