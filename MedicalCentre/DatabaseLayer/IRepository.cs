using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicalCentre.DatabaseLayer;

internal interface IRepository<T> where T : class
{
    public Task AddItemAsync(T newItem);
    public Task DeleteItemAsync(T newItem);
    public Task UpdateItemAsync(T item);

    public Task<IList<T>> GetTableAsync();

    public Task<T?> GetItemByIdAsync(uint id);

    public void DeleteItem(T newItem);

    public void AddItem(T newItem);

    public IList<T> GetTable();

    public T? GetItemById(uint id);
}
