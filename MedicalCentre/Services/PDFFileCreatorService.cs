using Aspose.Pdf;
using System.Windows;

namespace MedicalCentre.Services;

internal static class PDFFileCreatorService
{
    public static void CreatePdf(string path, string title, string text)
    {
        Document document = new Document();
        
        Page page = document.Pages.Add();

        page.Paragraphs.Add(new Aspose.Pdf.Text.TextFragment(title));
       
        page.Paragraphs.Add(new Aspose.Pdf.Text.TextFragment(text));

        document.Save($"{path}" + $"{title}.pdf");
        MessageBox.Show("Created");
    }
}
