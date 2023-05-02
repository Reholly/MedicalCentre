namespace MedicalCentre.Models;

public class Log
{
    public uint Id { get; set; }
    public string LogText { get; set; } = null!;
    public bool IsSuccess { get; set; }

    public Log() { }

    public Log(string logText, bool isSuccess)
    {
        LogText = logText;
        IsSuccess = isSuccess;
    }

    public Log(uint id, string logText, bool isSuccess)
    {
        Id = id;
        LogText = logText;
        IsSuccess = isSuccess;
    }
}