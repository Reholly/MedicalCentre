using System.Diagnostics;

namespace MedicalCentre.Services;

public static class OpenBrowserService
{
    public static void OpenPageInBrowser(string url)
    {
        System.Diagnostics.Process.Start(new ProcessStartInfo
        {
            FileName = url,
            UseShellExecute = true
        });
    }
}
