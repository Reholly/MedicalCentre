using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalCentre.DatabaseLayer
{
    public class ContextRepository<T> : IRepository<T>
        where T : class
    {
        private ApplicationContext context = new();

        public async Task AddItemAsync(T newItem)
        {
            await context.Set<T>().AddAsync(newItem);
            await context.SaveChangesAsync();
        }

        public async Task DeleteItemAsync(T newItem)
        {
            context.Set<T>().Remove(newItem);
            await context.SaveChangesAsync();
        }

        public async Task UpdateItemAsync(T item)
        {
            context.Set<T>().Update(item);
            await context.SaveChangesAsync();
        }

        public async Task<List<T>> GetTableAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T> GetItemByIdAsync(uint id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public void DeleteItem(T newItem)
        {
            context.Set<T>().Remove(newItem);
            context.SaveChanges();
        }

        public void AddItem(T newItem)
        {
            context.Set<T>().AddAsync(newItem);
            context.SaveChangesAsync();
        }

        public List<T> GetTable()
        {
            return context.Set<T>().ToList();
        }

        public T GetItemById(uint id)
        {
            return context.Set<T>().Find(id);
        }
    }
}