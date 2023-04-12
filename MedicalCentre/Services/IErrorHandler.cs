using System;

namespace MedicalCentre.Services;

public interface IErrorHandler
{
    void HandleError(Exception ex);
}