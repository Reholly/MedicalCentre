namespace MedicalCentre.Models;

public class StorageItem
{   
    public uint Id { get; set; }
    public string Name { get; set; }
    public uint Amount { get; set; }
    public uint Cost { get; set; }

    public StorageItem() { }

    public StorageItem(uint id, string name, uint amount, uint cost)
    {
        Id = id;
        Name = name;
        Amount = amount;
        Cost = cost;
    }
}