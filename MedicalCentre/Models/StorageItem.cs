namespace MedicalCentre.Models;

public class StorageItem
{
    public uint Id { get; set; }
    public string Name { get; set; }
    public uint Amount { get; set; }
    public decimal Cost { get; set; }

    public StorageItem() { }

    public StorageItem(uint id, string name, uint amount, decimal cost)
    {
        Id = id;
        Name = name;
        Amount = amount;
        Cost = cost;
    }
}