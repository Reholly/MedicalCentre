using MedicalCentre.DatabaseLayer;
using MedicalCentre.Models;
using System;
using System.Threading.Tasks;

namespace MedicalCentre.Services;

public static class TransactionCollectorService
{
    public static async Task CollectTransaction(string title, double price, TransactionType type)
    {
        ContextRepository<Transaction> transDb = new();
        await transDb.AddItemAsync(new Transaction(price, DateTime.Now, title, type));
    }
}
